namespace CanDriveTest;

[TestClass]
public class UnitTest1
{
    public bool CanDrive(int age)
    {
        const int drivingAge = 16;
        return age >= drivingAge;
    }
    
    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(false, CanDrive(int.MinValue));
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        Assert.AreEqual(false, CanDrive(int.MinValue + 1));
    }
    
    [TestMethod]
    public void TestMethod3()
    {
        Assert.AreEqual(false, CanDrive(15));
    }
    
    [TestMethod]
    public void TestMethod4()
    {
        Assert.AreEqual(true, CanDrive(16));
    }
    
    [TestMethod]
    public void TestMethod5()
    {
        Assert.AreEqual(true, CanDrive(17));
    }
    
    [TestMethod]
    public void TestMethod6()
    {
        Assert.AreEqual(true, CanDrive(int.MaxValue - 1));
    }
    
    [TestMethod]
    public void TestMethod7()
    {
        Assert.AreEqual(true, CanDrive(int.MaxValue));
    }
}