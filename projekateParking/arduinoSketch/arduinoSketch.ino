
#include<String.h>
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(3, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(7, INPUT);
  pinMode(9, INPUT);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available() > 0)
  {
    char znak = Serial.read();
    if(znak == 'a')
      dioda(3, 1);
    else if(znak == 'b')
      dioda(3, 0);
    else if(znak == 'c')
      dioda(5, 1);
    else if(znak == 'd')
      dioda(5, 0);
  }
  else if(digitalRead(7) == HIGH){
    Serial.write("U");
  }
  else if(digitalRead(9) == HIGH)
    Serial.write("I");
}

void dioda(int pin, int stanje)
{
  if(stanje == 1)
    digitalWrite(pin, HIGH);
  else
    digitalWrite(pin, LOW);
}

