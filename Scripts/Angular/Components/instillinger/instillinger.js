'use strict';

// Register `phoneList` component, along with its associated controller and template
angular.
  module('fenistra_leiekalkulator').
  component('instillinger', {
      templateUrl: "../Scripts/Angular/Components/instillinger/instillinger.html",
      controller: function instillingerController() {

          var self = this;

          self.avkastningskrav;
          self.inflasjon;
          self.TOAvskrivningsTid;
          self.LTAvskrivningsTid;

          if (localStorage.getItem("Avkastningskrav")) {
              self.avkastningskrav = localStorage.getItem("Avkastningskrav");
          }

          if (localStorage.getItem("inflasjon")) {
              self.inflasjon = localStorage.getItem("inflasjon");
          }

          if (localStorage.getItem("TOAvskrivningsTid")) {
              self.TOAvskrivningsTid = localStorage.getItem("TOAvskrivningsTid");
          }

          if (localStorage.getItem("LTAvskrivningsTid")) {
              self.LTAvskrivningsTid = localStorage.getItem("LTAvskrivningsTid");
          }


          self.leggtil = function () {

              localStorage.setItem("inflasjon", self.inflasjon);
              localStorage.setItem("TOAvskrivningsTid", self.TOAvskrivningsTid);
              localStorage.setItem("LTAvskrivningsTid", self.LTAvskrivningsTid);
              localStorage.setItem("Avkastningskrav", self.avkastningskrav);
          }
      }
  });