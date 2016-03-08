# HABANEROS
## eParking
Članovi Tima:

1. Hasan Grošić
2. Jasmin Hadžajlić
3. Samir Duraković
4. Ferhat Dobrača

### Opis teme

**eParking** je zamišljen kao sistem koji predstavlja proces parkiranja automobila u garažu namjenjenu različitim tipovima korisnika. 
Ovako realiziran parking bi korisnicima omogućio da iznajme parking mjesta u željeno vrijeme i na određeni period.
Na ovaj način se poboljšava organzovanje i funkcionisanje parkinga, izbjegavaju se svakodnevne gužve, te se obezbjeđuje veća sigurnost i dostupnost. 

### Procesi
####Parking proces
Parking proces je cjelokopni proces koji obuhvata sve podprocese i veze među njima. Na početku korisnik dolazi do ulaza u parking, gdje se odvija proces prepoznavanja.
Ukoliko proces prepoznavanja prepozna postojećeg korisnika, isti dobija podatak o slobodnom parking mjestu i otvara mu se prolaz na parking. Ukoliko kamera ne prepozna
korisnika kao postojećeg, korisnik se usmjerava na dio na kojem se vrši registracija. Ukoliko kamera nije u mogućnosti da prepozna korisnika, korisnik se ponovo upućuje
na dio za registraciju, zbog manuelnog prepoznavanja ili registracije, a upravnik provjerava sistem za prepoznavanje. Ukoliko se korisnik ne parkira na zadano mjesto, 
sistem signalizira korisniku da parkira na pogrešno mjesto. Ako korisnik ne poštuje signalizaciju, upravnik adekvatno djeluje. Naplata parkinga vrši se na izlazu sa parkinga
ili pri registraciji, u zavisnosti od paketa.
#####Proces prepoznavanja
Proces prepoznavanja vrši se pomoću kamere i odgovarajućeg software-a na osnovu registarskih oznaka vozila korisnika. Ako su registarske oznake prepoznate tokom ovog procesa,
sistem pronađe u bazi registrovanih korisnika, to vozilo se propušta u parking na odgovarajuće mjesto. U slučaju da se registarske oznake ne nalaze u bazi podataka, dolazi do obavljanja procesa registracije.
Ako se vozilo ne prepozna vrši se proces popravke kvara. 
#####Proces registracije
Proces registracije vrši se popunjavanjem aplikacije (samostalno ili sa službom za registraciju). Korisnik ostavlja lične podatke, te podatke o vozilu. Nakon toga odabire
tip paketa i vrstu rezervacije.
#####Proces popravke eventualnog kvara
Ukoliko je u toku Parking procesa došlo do greške, upravnik poziva osobu koja vrši popravku (tj. u slučaju software-skog kvara, obavještava Administratora IT sistema, a u slučaju
hardware-skog kvara, obavještava hardware tehničara).

### Funkcionalnosti

* Mogućnost prepoznavanja registarskih oznaka pomoću kamere
* Mogućnost registrovanja korisnika u bazu podataka parkinga
* Mogućnost praćenja popunjenosti parkinga
* Mogućnost signalizacije parkiranja na pogrešno mjesto
* Mogućnost parkiranja različitih vrsta vozila

### Akteri

1. Korisnik - vlasnik prevoznog sredstva, koji želi da koristi eParking.
Podjela korisnika:
 * prema vrsti vozila: automobil, kamion, autobus
 * prema tipu korisnika: autoprevozna kompanija, obični korisnik, specijalni korisnik(invalid, stalni korinik)
 * prema vrsti rezervacije parking mjesta: satni, dnevni, sedmični, mjesečni, godišnji

2. Upravnik - nadgleda rad eParkinga, detektuje eventualni kvar sistema, te u zavisnosti od kvara (software-ski, hardware-ski) angažuje odgovarajuće lice.

3. Administrator IT sistema - ukoliko dođe do software-skog kvara, analizira i rješava taj problem.

4. Hardware tehničar - ukoliko dođe do hardware-skog kvara, analizira i rješava taj problem.

5. Služba za registrovanje - služi za registraciju novih korisnika.

6. Blagajnik - naplaćuje izabranu uslugu korisniku.
