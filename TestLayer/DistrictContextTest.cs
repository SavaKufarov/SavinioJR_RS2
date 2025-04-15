using DataLayer;
using BusinessLayer;
using Google.Protobuf.WellKnownTypes;
using TestLayer;


namespace TestLayer
{
    [TestFixture]
    public class DistrictContextTest
    {
        static DistrictContext districtContext;
        static DistrictContextTest()
        {
            districtContext = new DistrictContext(TestManager.dbContext);
        }
        [Test]
        public void Createdistrict()
        {
            District district = new District("Programming");
            int districtsBefore = TestManager.dbContext.Districts.Count();
            districtContext.Create(district);
            int districtsAfter = TestManager.dbContext.Districts.Count();
            District lastdistrict = TestManager.dbContext.Districts.Last();
            Assert.That(districtsBefore + 1 == districtsAfter && lastdistrict.Name == district.Name, "No such district or Names do not match!");
        }
        [Test]
        public void Deletedistrict()
        {
            District newdistrict = new District("Sports");
            districtContext.Create(newdistrict);

            List<District> districts = districtContext.ReadAll();
            int districtBefore = districts.Count;
            District genre = districts.Last();

            districtContext.Delete(genre.Id);

            int genresAfter = districtContext.ReadAll().Count;
            Assert.That(districtBefore == genresAfter + 1, "Delete() does not delete a district!");
        }
        [Test]
        public void Readdistrict()
        {
            District newdistrict = new District("Martial arts");
            districtContext.Create(newdistrict);

            District genre = districtContext.Read(newdistrict.Id);

            Assert.That(genre.Name == "sport", "Read() does not get district by id!");
        }

        [Test]
        public void ReadAlldistricts()
        {
            int districtsBefore = TestManager.dbContext.Districts.Count();

            int districtsAfter = districtContext.ReadAll().Count;

            Assert.That(districtsBefore == districtsAfter, "ReadAll() does not return all of the districts!");
        }
        [Test]
        public void Updatedistrict()
        {
            District newdistrict = new District("Language");
            districtContext.Create(newdistrict);

            District lastdistrict = districtContext.ReadAll().Last();
            lastdistrict.Name = "Updated district";

            districtContext.Update(lastdistrict, false);

            Assert.That(districtContext.Read(lastdistrict.Id).Name == "Updated district",
            "Update() does not change the district's name!");
        }
    }
}