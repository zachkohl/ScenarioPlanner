using ScenarioPlanner;

namespace ScenarioPlannerTest
{
    public class ScenarioPlannerService_tests
    {
        [Fact]
        public void ScenarioPlannerService_addRoles_processesTheRoleString()
        {
            string roleString = "family, work,activities,fitness";

            ScenarioPlannerService myScenarioPlannerSerice = new ScenarioPlannerService();

            myScenarioPlannerSerice.addRoles(roleString);

            string[] roleArray = myScenarioPlannerSerice.getRoles();

            Assert.Equal(["family", "work", "activities", "fitness"], roleArray);
        }

        [Fact]
        public void ScenarioPlannerService_buildMarkdown_returns_properTable()
        {
            string roles = "work, play";
            string scenarios = "good, bad";
            string timeFrames = "next year, next 7 years";

            ScenarioPlannerService myScenarioPlannerSerice = new ScenarioPlannerService();

            string mockTableOutput =
  @"|           link           |           role           |         scenario         |        timeframe         |
|--------------------------|--------------------------|--------------------------|--------------------------|
| [[work-good-next_year]]  |           work           |           good           |        next year         |
|[[work-good-next_7_years]]|           work           |           good           |       next 7 years       |
|  [[work-bad-next_year]]  |           work           |           bad            |        next year         |
|[[work-bad-next_7_years]] |           work           |           bad            |       next 7 years       |
| [[play-good-next_year]]  |           play           |           good           |        next year         |
|[[play-good-next_7_years]]|           play           |           good           |       next 7 years       |
|  [[play-bad-next_year]]  |           play           |           bad            |        next year         |
|[[play-bad-next_7_years]] |           play           |           bad            |       next 7 years       |
";

            myScenarioPlannerSerice.addRoles(roles);
            myScenarioPlannerSerice.addScenarios(scenarios);
            myScenarioPlannerSerice.addTimeFrames(timeFrames);

            string table = myScenarioPlannerSerice.getTable();

            Assert.Equal(mockTableOutput, table);



        }

    }
}
