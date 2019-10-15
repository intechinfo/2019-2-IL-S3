using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace ITI.MicroZoo
{
    public class Bird : Animal
    {
        bool _isFlying;

        internal Bird(Zoo context, string name)
            : base(context, name)
        {
        }

        public override void Kill()
        {
            if (!IsAlive) throw new InvalidOperationException("This bird is already dead.");

            IMailService mailService = Zoo.MailService;
            mailService.SendMail(
                "antoine.raquillet@esiea.fr",
                "A bird is dying.",
                string.Format("{0} is dying.", Name));

            base.Kill();
        }

        internal override void Update()
        {
            if (_isFlying)
            {
                Position = Zoo.GetRandomPosition();
                Energy = Math.Max(0.0, Energy - Zoo.Options.EnergyDecreaseDelta);
                if (Energy <= Zoo.Options.LandingLimit) _isFlying = false;
            }
            else
            {
                Energy = Math.Min(1.0, Energy + Zoo.Options.EnergyIncreaseDelta);
                if (Energy >= Zoo.Options.FlyingLimit) _isFlying = true;
            }
        }
    }
}
