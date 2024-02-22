namespace ArticleEditor.UnitTests.EnumTests;

[TestFixture]
public class MonthTests
{
    [Test]
    public void Enum_Values_MatchExpectations()
    {
        Assert.Multiple(() =>
        {
            Assert.That((int)Month.January, Is.EqualTo(1));
            Assert.That((int)Month.February, Is.EqualTo(2));
            Assert.That((int)Month.March, Is.EqualTo(3));
            Assert.That((int)Month.April, Is.EqualTo(4));
            Assert.That((int)Month.May, Is.EqualTo(5));
            Assert.That((int)Month.June, Is.EqualTo(6));
            Assert.That((int)Month.July, Is.EqualTo(7));
            Assert.That((int)Month.August, Is.EqualTo(8));
            Assert.That((int)Month.September, Is.EqualTo(9));
            Assert.That((int)Month.October, Is.EqualTo(10));
            Assert.That((int)Month.November, Is.EqualTo(11));
            Assert.That((int)Month.December, Is.EqualTo(12));
        });
    }

    [Test]
    public void Enum_Parse_ValidValues()
    {
        Assert.Multiple(() =>
        {
            foreach (Month month in Enum.GetValues(typeof(Month)))
            {
                var parsedMonth = Enum.Parse<Month>(month.ToString());
                Assert.That(parsedMonth, Is.EqualTo(month));
            }
        });
    }

    [Test]
    public void Enum_Parse_InvalidValue_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => Enum.Parse<Month>("InvalidMonth"));
    }

    [Test]
    public void Enum_Values_Exist()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Enum.IsDefined(typeof(Month), Month.January), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.February), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.March), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.April), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.May), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.June), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.July), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.August), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.September), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.October), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.November), Is.True);
            Assert.That(Enum.IsDefined(typeof(Month), Month.December), Is.True);
        });
    }

    [Test]
    public void Enum_Values_Count()
    {
        var values = Enum.GetValues(typeof(Month));
        Assert.That(values.Length, Is.EqualTo(12));
    }
}