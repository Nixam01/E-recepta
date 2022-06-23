using AppController;
using AppModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void ShouldLoadAllDrugs()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            IController controller = new Controller(new EmptyEventDispatcher(), model);

            controller.SearchDrugsAsync().Wait();

            int expectedCount = 3;

            int actualCount = model.DrugList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Drug count should be {0} and not {1}", expectedCount, actualCount);
        }

        [TestMethod]
        public void ShouldLoadAllDoctors()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            IController controller = new Controller(new EmptyEventDispatcher(), model);

            controller.SearchDoctorsAsync().Wait();

            int expectedCount = 3;

            int actualCount = model.DoctorList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Doctor count should be {0} and not {1}", expectedCount, actualCount);
        }

        [TestMethod]
        public void ShouldLoadAllPatientPrescriptions()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            string pesel = "48101179872";

            model.SearchText = pesel;

            IController controller = new Controller(new EmptyEventDispatcher(), model);

            controller.SearchPrescriptionsAsync().Wait();

            int expectedCount = 1;

            int actualCount = model.PrescriptionList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Prescription count should be {0} and not {1}", expectedCount, actualCount);
        }

        [TestMethod]
        public void ShouldNotLoadPatientPrescriptions_neg()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            string pesel = "123";

            model.SearchText = pesel;

            IController controller = new Controller(new EmptyEventDispatcher(), model);

            controller.SearchPrescriptionsAsync().Wait();

            int expectedCount = 0;

            int actualCount = model.PrescriptionList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Prescription count should be {0} and not {1}", expectedCount, actualCount);
        }
    }
}
