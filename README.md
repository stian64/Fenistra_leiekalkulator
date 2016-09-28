# Fenistra_leiekalkulator


Jeg tenkte først å lage dette i Angular 2, som jeg akuratt har begynt å lære , men grunnet liten tid valgte jeg å bruke Angular 1.5 som jeg forsåvidt ikke har brukt før eller. Men det er nærmere syntax jeg er vant med og Webcomponeneter er utgitt i den.

Grunnet Tidsbegrensninger har jeg valgt å gjøre http request via jquery direkte fra beregnings komponenten. Jeg ville heller ha laget en service factory for http requestene så koden i komponentene er renener,så den har mindre ansvar og at http requesten da kan gjenbrukes i andre komponenter om de oppstår behov.

Beregningene er lagt i en model, jeg var litt usikker på om det ble riktig sted, men det er nå pågrunn av at metodene nå er tilgjennglig for gjenbruk av andre controllere.

Jeg brukte en ajax get metode for å sende og returnere all data. Valgte dette istedenfor mange ajax requests , blant annet fordi instancen av controlleren ikke vil holde til neste call og dermed må mye data gjentas inn og, LoadDefaultValues metoden ville ikke gitt så mye mening.

bootstrap er i bruk for utseendet og input er lagret over tid via localstorage.

grunnet liten tid fikk jeg ikke inn noe arbeid på browser spesifiserte forskjeller. Men jeg ville brukt conditional statements for å gi ulike css filer iforhold til browseren brukeren har og Modernizr til hjelp.
