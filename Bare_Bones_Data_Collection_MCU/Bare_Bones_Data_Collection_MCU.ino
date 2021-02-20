/*
 * Bare Bones Data Communication
 * 
 * Instructions:
 * 1. Plug in your Arduino-compatible board
 * 2. Select the board and COM port in the Tools menu
 * 3. Upload code!
 * 4. To test, open the Serial Monitor (top right corner magnifying glass)
 */

// Setup runs first, once and only once, before going into the Loop
void setup() {

  delay(1000); // wait a second (1000 milliseconds), just a good habit at the beginning of your code
  
  Serial.begin(9600); // start the serial communication (USB) at the standard 9600 baud (bits per second)
  delay(500); // good habit to wait a half second after starting up serial communication
}

// Loop runs after Setup, and repeats until you reset or power down your microcontroller
void loop() {

  // REPLACE THIS WITH YOUR SENSOR CODE!!
  double random_Data = random(1,100) / (double)100; // generates a random number between .1 and 1
  
  Serial.println(random_Data); // send the value as a character string over serial

  // CHANGE THIS TO YOUR DESIRED DATA TRANSMISSION FREQUENCY (as a time interval where Interval = 1 / Frequency)
  delay(2000); // wait 2 seconds before sending the next dummy value (AKA data frequency of 0.5 Hertz)
}
