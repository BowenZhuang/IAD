
 //FILE          : lightLevelLed.ino
 //PROJECT       : IAd - Final Project
 //PROGRAMMER    : Bowen Zhuang, Linyan Li, Kevin Li
 //FIRST VERSION : 2015-04-13
 //DESCRIPTION   : A simple programme that will change the intensity of
 // 				an LED based  * on the amount of light incident on 
 // 				the photo resistor. Then, data is sent to a PC using 
 //					a serial port within every 2 second
 
#include "Timer.h"


//PhotoResistor Pin
int lightPin = 0; //the analog pin the photoresistor is 
                  //connected to
                  //the photoresistor is not calibrated to any units so
                  //this is simply a raw sensor value (relative light)
//LED Pin
int ledPin = 9;   //the pin the LED is connected to
                  //we are controlling brightness so 
                  //we use one of the PWM (pulse width
                  // modulation pins)
int lightLevel=0;
int ledLevel=0;

Timer t;
void setup()
{
  Serial.begin(9600);           // set up Serial library at 9600 bps
  pinMode(ledPin, OUTPUT); //sets the led pin to output
  t.every(2000, takeReading);
}
 /*
 * loop() - this function will start after setup 
 * finishes and then repeat
 */
void loop()
{
  t.update();  
  
  lightLevel = analogRead(lightPin); //Read the
                                        // lightlevel

  ledLevel = lightLevel;
  
 ledLevel = map(ledLevel, 0, 900, 0, 255); 
         //adjust the value 0 to 900 to
         //span 0 to 255
 ledLevel = constrain(ledLevel, 0, 255);//make sure the 
                                           //value is betwween 
                                           //0 and 255
 analogWrite(ledPin, ledLevel);  //write the value
  

}

void takeReading()
{

 Serial.println(lightLevel,DEC);
 Serial.println(ledLevel,DEC); 
}
