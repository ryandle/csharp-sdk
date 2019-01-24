﻿/* 
 * Copyright 2019, Optimizely
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Moq;
using NUnit.Framework;
using OptimizelySDK.Entity;
using OptimizelySDK.Logger;
using OptimizelySDK.Utils;

namespace OptimizelySDK.Tests.UtilsTests
{
    [TestFixture]
    public class ExperimentUtilsTest
    {
        private ProjectConfig Config;
        private Mock<ILogger> LoggerMock;
        private ILogger Logger;

        [SetUp]
        public void Setup()
        {
            Config = ProjectConfig.Create(TestData.TypedAudienceDatafile, null, null);
            LoggerMock = new Mock<ILogger>();
            LoggerMock.Setup(l => l.Log(It.IsAny<LogLevel>(), It.IsAny<string>()));
            Logger = LoggerMock.Object;
        }
        
        #region IsUserInExperiment Tests

        [Test]
        public void TestIsUserInExperimentReturnsTrueWithNoAudience()
        {
            var experiment = Config.GetExperimentFromKey("feat_with_var_test");
            experiment.AudienceIds = new string[] { };
            experiment.AudienceConditions = null;

            Assert.True(ExperimentUtils.IsUserInExperiment(Config, experiment, null, Logger));
        }

        [Test]
        public void TestIsUserInExperimentReturnsTrueWhenAudienceUsedInExperimentNoAttributesProvided()
        {
            var experiment = Config.GetExperimentFromKey("feat_with_var_test");
            experiment.AudienceIds = new string[] { "3468206648" };
            var audienceConditions = Config.GetAudience("3468206648").Conditions;

            Assert.True(ExperimentUtils.IsUserInExperiment(Config, experiment, null, Logger));
            Assert.True(ExperimentUtils.IsUserInExperiment(Config, experiment, new UserAttributes { }, Logger));
            
            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Starting to evaluate audience ""3468206648"" with conditions: ""{audienceConditions}"""), Times.Exactly(2));
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, $@"Audience ""3468206648"" evaluated to ""TRUE"""), Times.Exactly(2));
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audiences for experiment ""feat_with_var_test"" collectively evaluated to ""TRUE"""), Times.Exactly(2));
        }

        [Test]
        public void TestIsUserInExperimentReturnsFalseIfNoAudienceInORConditionPass()
        {
            var experiment = Config.GetExperimentFromKey("feat_with_var_test");
            var userAttributes = new UserAttributes
            {
                { "house", "Ravenclaw" },
                { "lasers", 50 },
                { "should_do_it", false }
            };

            Assert.False(ExperimentUtils.IsUserInExperiment(Config, experiment, userAttributes, Logger));
        }

        [Test]
        public void TestIsUserInExperimentReturnsTrueIfAnyAudienceInORConditionPass()
        {
            var experiment = Config.GetExperimentFromKey("feat_with_var_test");
            var userAttributes = new UserAttributes
            {
                { "house", "Gryffindor" },
                { "lasers", 50 },
                { "should_do_it", false }
            };

            Assert.True(ExperimentUtils.IsUserInExperiment(Config, experiment, userAttributes, Logger));
        }

        [Test]
        public void TestIsUserInExperimentReturnsTrueIfAllAudiencesInANDConditionPass()
        {
            var experiment = Config.GetExperimentFromKey("audience_combinations_experiment");
            var userAttributes = new UserAttributes
            {
                { "house", "Gryffindor" },
                { "favorite_ice_cream", "walls" }
            };

            Assert.True(ExperimentUtils.IsUserInExperiment(Config, experiment, userAttributes, Logger));
        }

        [Test]
        public void TestIsUserInExperimentReturnsFalseIfAnyAudienceInANDConditionDoesNotPass()
        {
            var audience3468206642Conditions = Config.GetAudience("3468206642").Conditions;
            var audience3988293899Conditions = Config.GetAudience("3988293899").Conditions;
            var audience3468206646Conditions = Config.GetAudience("3468206646").Conditions;
            var audience3468206647Conditions = Config.GetAudience("3468206647").Conditions;
            var audience3468206644Conditions = Config.GetAudience("3468206644").Conditions;
            var audience3468206643Conditions = Config.GetAudience("3468206643").Conditions;
            var experiment = Config.GetExperimentFromKey("audience_combinations_experiment");
            var userAttributes = new UserAttributes
            {
                { "house", "Gryffindor" },
                { "lasers", 50 }
            };

            Assert.False(ExperimentUtils.IsUserInExperiment(Config, experiment, userAttributes, Logger));

            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Evaluating audiences for experiment ""audience_combinations_experiment"": ""{experiment.AudienceConditions}"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Starting to evaluate audience ""3468206642"" with conditions: ""{audience3468206642Conditions}"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audience ""3468206642"" evaluated to ""TRUE"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Starting to evaluate audience ""3988293899"" with conditions: ""{audience3988293899Conditions}"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audience ""3988293899"" evaluated to ""FALSE"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Starting to evaluate audience ""3468206646"" with conditions: ""{audience3468206646Conditions}"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audience ""3468206646"" evaluated to ""FALSE"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Starting to evaluate audience ""3468206647"" with conditions: ""{audience3468206647Conditions}"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audience ""3468206647"" evaluated to ""FALSE"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Starting to evaluate audience ""3468206644"" with conditions: ""{audience3468206644Conditions}"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audience ""3468206644"" evaluated to ""FALSE"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.DEBUG, $@"Starting to evaluate audience ""3468206643"" with conditions: ""{audience3468206643Conditions}"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.WARN, @"Audience condition ""{""Type"":""custom_attribute"",""Match"":""exact"",""Name"":""should_do_it"",""Value"":true}"" evaluated to UNKNOWN because no value was passed for user attribute ""should_do_it"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audience ""3468206643"" evaluated to ""UNKNOWN"""), Times.Once);
            LoggerMock.Verify(l => l.Log(LogLevel.INFO, @"Audiences for experiment ""audience_combinations_experiment"" collectively evaluated to ""FALSE"""), Times.Once);
        }

        [Test]
        public void TestIsUserInExperimentReturnsTrueIfAudienceInNOTConditionDoesNotPass()
        {
            var experiment = Config.GetExperimentFromKey("feat_with_var_test");
            experiment.AudienceIds = new string[] { "3468206645" };
            var userAttributes = new UserAttributes
            {
                { "browser_type", "Safari" }
            };

            Assert.True(ExperimentUtils.IsUserInExperiment(Config, experiment, userAttributes, Logger));
        }

        [Test]
        public void TestIsUserInExperimentReturnsFalseIfAudienceInNOTConditionGetsPassed()
        {
            var experiment = Config.GetExperimentFromKey("feat_with_var_test");
            experiment.AudienceIds = new string[] { "3468206645" };
            var userAttributes = new UserAttributes
            {
                { "browser_type", "Chrome" }
            };

            Assert.False(ExperimentUtils.IsUserInExperiment(Config, experiment, userAttributes, Logger));
        }

        #endregion // IsUserInExperiment Tests
    }
}
