'use strict';

// Register `phoneList` component, along with its associated controller and template
angular.
  module('fenistra_leiekalkulator').
  component('beregning', {
      templateUrl: "../Scripts/Angular/Components/beregning/beregning.html",
      controller:  function BeregningerController(){

          var self = this;
          
          //Input
          self.areal;
          self.grunnleie;
          self.terminer;
          self.leietakertilpasning;
          self.teknisk_oppgradering;


          self.inflasjon = localStorage.getItem("inflasjon");
          self.avkastningskrav = localStorage.getItem("Avkastningskrav");
          self.TOAvskrivningsTid = localStorage.getItem("TOAvskrivningsTid");
          self.LTAvskrivningsTid = localStorage.getItem("LTAvskrivningsTid");

          if (localStorage.getItem("areal")) {
              self.areal = localStorage.getItem("areal");
          }

          if (localStorage.getItem("grunnleie")) {
              self.grunnleie = localStorage.getItem("grunnleie");
          }

          if (localStorage.getItem("terminer")) {
              self.terminer = localStorage.getItem("terminer");
          }

          if (localStorage.getItem("leietakertilpasning")) {
              self.leietakertilpasning = localStorage.getItem("leietakertilpasning");
          }

          if (localStorage.getItem("teknisk_oppgradering")) {
              self.teknisk_oppgradering = localStorage.getItem("teknisk_oppgradering");
          }


          //Output
          self.LTAnnFaktor;
          self.LTLeiePerAr;
          self.LTLeiePerM2;
          self.Oppusingtotal;
          self.Realrente;
          self.TOLeiePerAr;
          self.TOLeiePerM2;
          self.ToAnnFaktor;
          self.TotalLeiePerAr;
          self.TotalLeiePerM2;
          self.TotaltPerM2;
          self.TilleggKostnLeiePrAarTotalt;
          self.TilleggKostnLeiePrKvmTotalt;


          self.beregn = function () {


              if (self.areal != null && self.grunnleie != null && self.terminer != null && self.leietakertilpasning != null && self.teknisk_oppgradering != null) {
    
                  localStorage.setItem("areal", self.areal);
                  localStorage.setItem("grunnleie", self.grunnleie);
                  localStorage.setItem("terminer", self.terminer);
                  localStorage.setItem("leietakertilpasning", self.leietakertilpasning);
                  localStorage.setItem("teknisk_oppgradering", self.teknisk_oppgradering);


                  $.ajax({
                      url: "/Beregninger/getkostnader",
                      type: 'get',
                      data: {
                          '_ArealM2': self.areal, '_Grunnleie': self.grunnleie, '_Terminer': self.terminer,
                          '_LeietakerTilpasning': self.leietakertilpasning, '_TekniskOppgradering': self.teknisk_oppgradering, '_Inflasjon': self.inflasjon,
                          '_AvkastningsKrav': self.avkastningskrav, '_LTAvskrivningsTid': self.LTAvskrivningsTid, '_TOAvskrivningsTid': self.TOAvskrivningsTid
                      },                     
                      dataType: "json",
                      traditional: true
                  }).done(function (result) {

                      self.LTAnnFaktor = result.LTAnnFaktor;
                      self.LTLeiePerAr = result.LTLeiePerAr;
                      self.LTLeiePerM2 = result.LTLeiePerM2;
                      self.Oppusingtotal = result.Oppusingtotal;
                      self.Realrente = result.Realrente;
                      self.TOLeiePerAr = result.TOLeiePerAr;
                      self.TOLeiePerM2 = result.TOLeiePerM2;
                      self.ToAnnFaktor = result.ToAnnFaktor;
                      self.TotalLeiePerAr = result.TotalLeiePerAr;
                      self.TotalLeiePerM2 = result.TotalLeiePerM2;
                      self.TotaltPerM2 = result.TotaltPerM2;
                      self.TilleggKostnLeiePrAarTotalt = result.TilleggKostnLeiePrAarTotalt;
                      self.TilleggKostnLeiePrKvmTotalt = result.TilleggKostnLeiePrKvmTotalt;

                  }).fail(function (xhr, status, error) {
                      var htmlResponseDoc = $.parseHTML(xhr.responseText);
                      var $html = $(htmlResponseDoc);
                      var internalServerMessage = $html.filter("title").text();

                  });


              }             

          }
         
      }    
  });
