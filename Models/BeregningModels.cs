using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fenistra_leiekalkulator.Models
{
    public class BeregningModels
    {


        private double ArealM2,Grunnleie,Terminer,LTAvskrivningsTid,TOAvskrivningsTid, Inflasjon, AvkastningsKrav;
        private int LeietakerTilpasning, TekniskOppgradering;


        public BeregningModels(double _ArealM2, double _Grunnleie, double _Terminer, int _LeietakerTilpasning, int _TekniskOppgradering, double _Inflasjon, double _AvkastningsKrav, double _LTAvskrivningsTid, double _TOAvskrivningsTid)
        {
            ArealM2 = _ArealM2;
            Grunnleie = _Grunnleie;
            Terminer = _Terminer;
            LTAvskrivningsTid = _LTAvskrivningsTid;
            LeietakerTilpasning = _LeietakerTilpasning;
            TekniskOppgradering = _TekniskOppgradering;
            Inflasjon = _Inflasjon;
            AvkastningsKrav = _AvkastningsKrav;
            LTAvskrivningsTid = _LTAvskrivningsTid;
            TOAvskrivningsTid = _TOAvskrivningsTid;
        }

      public void LoadDefaultValues()
      {

            ArealM2 = 100;

            Grunnleie = 1200;

            Terminer = 4;

            LeietakerTilpasning = 30000;

            TekniskOppgradering = 15000;

            Inflasjon = 0.025f;

            AvkastningsKrav = 0.075f;

            LTAvskrivningsTid = 5;

            TOAvskrivningsTid = 20;

        }
  
        //Beregnings properties

        public float Realrente
        {

            get
            {

                return (float)decimal.Round((decimal)(AvkastningsKrav - Inflasjon), 2);

            }

        }

        public float OppusningskostTotalt
        {

            get
            {

                return (float)decimal.Round(LeietakerTilpasning + TekniskOppgradering, 2);

            }

        }

        public float LTAnnFaktor
        {

            get
            {

                double ltAnnFaktor = 0;

                try

                {

                    if (Terminer == 0)

                        return 0;

                    ltAnnFaktor = Terminer * (1 + Realrente / Terminer) * (1 - (1 / (1 + Realrente / Terminer))) / (1 - (1 / (Math.Pow(1 + (Realrente / Terminer), (LTAvskrivningsTid * Terminer)))));

                }

                catch

                {

                    return 0;

                }

                if (double.IsNaN(ltAnnFaktor) || (double.IsInfinity(ltAnnFaktor)))

                {

                    return 0;

                }

                return (float)ltAnnFaktor;

            }

        }

        public float TOAnnFaktor
        {

        get
            {

                if (Terminer == 0)

                    return 0;

                double toAnnFaktor = 0;

                toAnnFaktor = Terminer * (1 + Realrente / Terminer) * (1 - (1 / (1 + Realrente / Terminer))) / (1 - (1 / (Math.Pow(1 + (Realrente / Terminer), (TOAvskrivningsTid * Terminer)))));

                if (double.IsNaN(toAnnFaktor) || (double.IsInfinity(toAnnFaktor)))

                {

                    return 0;

                }

                return (float)toAnnFaktor;

            }

        }

        public float LTTilleggKostnLeiePrAar
        {

            get
            {

                return (float)decimal.Round((decimal)(LTAnnFaktor * LeietakerTilpasning), 0);

            }

        }

        public float TOTilleggKostnLeiePrAar
        {

            get
            {

                return (float)decimal.Round((decimal)(TOAnnFaktor * TekniskOppgradering), 0);

            }

        }

        public float TilleggKostnLeiePrAarTotalt
        {

            get
            {

                return (float)decimal.Round((decimal)(LTTilleggKostnLeiePrAar + TOTilleggKostnLeiePrAar

                ), 0);

            }

        }

        public float LTTilleggKostnLeiePrKvm
        {

            get
            {

                if (ArealM2 == 0)

                    return 0;

                return (float)decimal.Round((decimal)(LTTilleggKostnLeiePrAar / ArealM2), 0);

            }

        }

        public float TOTilleggKostnLeiePrKvm
        {

            get
            {

                if (ArealM2 == 0)

                    return 0;
            
             return (float)decimal.Round((decimal)(TOTilleggKostnLeiePrAar / ArealM2), 0);

            }

        }

        public float TilleggKostnLeiePrKvmTotalt

        {

            get
            {

                return (float)decimal.Round((decimal)(LTTilleggKostnLeiePrKvm + TOTilleggKostnLeiePrKvm

                ), 0);

            }

        }

        public float TotaltLeiePrAar
        {

            get
            {

                return (float)decimal.Round((decimal)(((LTTilleggKostnLeiePrKvm + TOTilleggKostnLeiePrKvm) + Grunnleie) *ArealM2), 0);

            }

        }
                            

        public float TotaltLeiePrKvm
        {

            get
            {

                if (ArealM2 == 0)

                    return 0;

                return (float)decimal.Round((decimal)(TotaltLeiePrAar / ArealM2), 0);

            }

        }


    }
}