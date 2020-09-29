using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace Tests
{
    public class StubAndMock
    {
        [Fact]
        public void DoisDireBonjourEnJournee()
        {
            Mock<IDonneHeure> mock = new Mock<IDonneHeure>();
            mock.Setup(h => h.DonneHeure()).Returns(new DateTime(2000, 08, 17, 17, 59,00));
            Horloge horloge= new Horloge(mock.Object);
            Assert.Equal("Bonjour", horloge.Parle() );
        }

        [Fact]
        public void DoisDireBonsoirEnSoiree()
        {
            Mock<IDonneHeure> mock = new Mock<IDonneHeure>();
            mock.Setup(h => h.DonneHeure()).Returns(new DateTime(2000, 08, 17, 19, 59, 00));
            Horloge horloge = new Horloge(mock.Object);
            Assert.Equal("Bonsoir", horloge.Parle());
        }


        public interface IMissileLauncher
        {
            void LancerMissile();
        }

        [Fact]
        public void lanceUnMissileSiLeMotEstTrump()
        {
            Mock<IMissileLauncher> mock = new Mock<IMissileLauncher>();
            Pilote pilote = new Pilote(mock.Object);
            pilote.MotSecret("Trump");
            mock.Verify(m=>m.LancerMissile(),Times.Once);
        }


        [Fact]
        public void neLancePasDeMissileSiLeMotNEstPasTrump()
        {
            Mock<IMissileLauncher> mock = new Mock<IMissileLauncher>();
            Pilote pilote = new Pilote(mock.Object);
            pilote.MotSecret("Kim");
            mock.Verify(m => m.LancerMissile(), Times.Never);
        }

    }

    public class Pilote
    {
        private readonly StubAndMock.IMissileLauncher launcher;

        public Pilote(StubAndMock.IMissileLauncher launcher)
        {
            this.launcher = launcher;
        }

        public void MotSecret(string trump)
        {
            if (trump == "Trump")
            {
                launcher.LancerMissile();

            }
        }
    }

    public interface IDonneHeure
    {
        DateTime DonneHeure();
    }

    class DonneHeureGlop : IDonneHeure
    {
        public DateTime DonneHeure()
        {
            return DateTime.Now;
        }
    }

    public class Horloge
    {
        private IDonneHeure donneHeure;

        public Horloge(IDonneHeure donneHeure)
        {
            this.donneHeure = donneHeure;
        }

        public string Parle()
        {
            var date = donneHeure.DonneHeure();
            if (date.Hour >= 19)
            {
                return "Bonsoir";
            }
            return "Bonjour";
        }
    }
}
