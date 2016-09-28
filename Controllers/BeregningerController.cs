using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fenistra_leiekalkulator.Models;

namespace Fenistra.Controllers
{
    public class BeregningerController : Controller
    {

        private BeregningModels beregningmodel;


      [HttpGet]
        public JsonResult getkostnader(double _ArealM2,double _Grunnleie, double _Terminer, int _LeietakerTilpasning, int _TekniskOppgradering, double _Inflasjon, double _AvkastningsKrav,double _LTAvskrivningsTid, double _TOAvskrivningsTid)
        {
            beregningmodel = new BeregningModels(_ArealM2,  _Grunnleie, _Terminer,  _LeietakerTilpasning, _TekniskOppgradering,  _Inflasjon,  _AvkastningsKrav,  _LTAvskrivningsTid, _TOAvskrivningsTid);


            DataDto datadto = new DataDto();

            datadto.Oppusingtotal = beregningmodel.OppusningskostTotalt;
            datadto.Realrente = beregningmodel.Realrente;
            datadto.LTAnnFaktor = beregningmodel.LTAnnFaktor;
            datadto.ToAnnFaktor = beregningmodel.TOAnnFaktor;
            datadto.TotaltPerM2 = beregningmodel.TotaltLeiePrKvm;
            datadto.TilleggKostnLeiePrKvmTotalt = beregningmodel.TilleggKostnLeiePrKvmTotalt;
            datadto.TotalLeiePerAr = beregningmodel.TotaltLeiePrAar;
            datadto.TOLeiePerAr = beregningmodel.TOTilleggKostnLeiePrAar;
            datadto.TOLeiePerM2 = beregningmodel.TOTilleggKostnLeiePrKvm;
            datadto.LTLeiePerAr = beregningmodel.LTTilleggKostnLeiePrAar;
            datadto.LTLeiePerM2 = beregningmodel.LTTilleggKostnLeiePrKvm;
            datadto.TotalLeiePerM2 = beregningmodel.TotaltLeiePrKvm;
            datadto.TilleggKostnLeiePrAarTotalt = beregningmodel.TilleggKostnLeiePrAarTotalt;



            return Json(datadto, JsonRequestBehavior.AllowGet);
        }

    
    }


    public class DataDto
    {
        public double Realrente;
        public double TotalLeiePerAr;
        public double TotalLeiePerM2;
        public float Oppusingtotal;
        public double TotaltPerM2;
        public float ToAnnFaktor;
        public float LTAnnFaktor;
        public double LTLeiePerAr;
        public double TOLeiePerAr;
        public double LTLeiePerM2;
        public double TOLeiePerM2;
        public double TilleggKostnLeiePrAarTotalt;
        public double TilleggKostnLeiePrKvmTotalt;


    }
}