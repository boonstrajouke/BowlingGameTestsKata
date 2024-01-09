using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest;

public class Game
{
    private int[] rolls = new int[21];
    private int currentRoll;

    public void Roll(int pins)
    {
        rolls[currentRoll++] = pins;
    }

    public int Score()
    {
        int score = 0;
        int roll = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            // spare
            if (IsSpare(roll))
            {
                score += 10 + rolls[roll + 2];
            }
            else
            {
                score += rolls[roll] + rolls[roll + 1];
            }
            roll += 2;
        }

        return score;
    }

    private bool IsSpare(int roll)
    {
        return rolls[roll] + rolls[roll + 1] == 10;
    }
}

[TestClass]
public class GameTest
{
    private TestContext testContextInstance;
    public TestContext TestContext
    {
        get { return testContextInstance; }
        set { testContextInstance = value; }
    }

    private Game g;

    [TestInitialize]
    public void Initialize()
    {
        g = new Game();
    }

    [TestCleanup]
    public void Cleanup()
    {
        g = null;
    }

    [TestMethod]
    public void TestGutterGame()
    {
        int rolls = 20;
        int pins = 0;

        RollMany(20, 0);
        // Game g = new Game();
        for (int i = 0; i< 20; i++)
        {
           g.Roll(0);
        }
        Assert.AreEqual(0, g.Score());
    }

    [TestMethod]
    public void TestAllOnes()
    {
        RollMany(20, 1);

        Assert.AreEqual(20, g.Score());
    }

    private void RollMany(int rolls, int pins)
    {
        for (int i = 0; i < rolls; i++)
        {
            g.Roll(pins);
        }
    }

    [TestMethod]
    public void TestOneSpare()
    {
        g.Roll(5);
        g.Roll(5); // spare
        g.Roll(3);
        RollMany(16, 0);
        Assert.AreEqual(24, g.Score());
    }

    private void RollSpare()
    {
        g.Roll(5);
        g.Roll(5);
    }
}
