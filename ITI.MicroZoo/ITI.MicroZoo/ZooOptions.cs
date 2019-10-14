namespace ITI.MicroZoo
{
    public class ZooOptions
    {
        public ZooOptions()
        {
            CatSpeed = 0.15;
            BirdSpeed = 0.20;
            EnergyIncreaseDelta = 0.05;
            EnergyDecreaseDelta = 0.1;
            FlyingLimit = 0.8;
            LandingLimit = 0.2;
        }

        public double CatSpeed { get; set; }

        public double BirdSpeed { get; set; }

        public double EnergyIncreaseDelta { get; set; }

        public double EnergyDecreaseDelta { get; set; }

        public double FlyingLimit { get; set; }

        public double LandingLimit { get; set; }
    }
}
