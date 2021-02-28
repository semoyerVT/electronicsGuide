/*
 * For wiring see https://randomnerdtutorials.com/esp32-ds18b20-temperature-arduino-ide/
 * Use the 'Normal Mode' wiring, resistor doesn't have to be exact (within ~1k is fine)
 */

// Libraries (you will need to install these... see https://randomnerdtutorials.com/esp32-ds18b20-temperature-arduino-ide/)
#include <OneWire.h>
#include <DallasTemperature.h>

// Pin used for one wire communication on the ExpressIf ESP32
#define ONE_WIRE_BUS (5)

// Desired time interval between measurements (in milliseconds)
#define DATA_INTERVAL (2000)

// Set to 'true' to print all outputs over USB serial, 'false' to print only the sensor data
#define PRINT_ALL (false)

// The LED is used to indicate an ERROR, note that some ESP32 modules have an on-board LED
#define LED_PIN (19)

// The OneWire instance used for the Dallas sensor
OneWire oneWire(ONE_WIRE_BUS);

// The Sensor instance
DallasTemperature sensor(&oneWire);

// To store the sensor's address per OneWire protocol
DeviceAddress deviceAddress;

void setup()
{
  // Set up the LED pin, which will turn ON if there is an issue
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  // Start up the USB Serial communication
  delay(100);
  Serial.begin(9600);
  delay(1000);

  // Start up the Sensor communication
  sensor.begin();
  delay(100);

  if (PRINT_ALL) Serial.print("\n\nTesting sensor communication... ");
  delay(100);

  // Verify Sensor is able to communicate
  if (sensor.getDeviceCount() == 0)
  {
    digitalWrite(LED_PIN, HIGH); // Indicate ERROR

    while (true)
    {
      Serial.println("FAILED, Check wiring and pinout then reset board");
      delay(2000);
    }
  }

  // Sensor communication verified
  if (PRINT_ALL) Serial.println("PASS, Communication verified");
  if (PRINT_ALL) Serial.print("Checking for valid sensor address... ");
  delay(100);

  // Verify Sensor uses proper addressing
  if (!sensor.getAddress(deviceAddress, 0))
  {
    digitalWrite(LED_PIN, HIGH); // Indicate ERROR

    while (true)
    {
      Serial.println("FAILED, Check wiring and pinout then reset board");
      delay(2500);
    }
  }

  // Sensor addressing verified
  if (PRINT_ALL) Serial.print("PASS, Device Address: ");
  if (PRINT_ALL) printAddress(deviceAddress);

  if (PRINT_ALL) Serial.println("\nStarting measurement stream...\n");
  delay(100);
}

void loop(void)
{
  // Send the command to get temperature from sensor
  sensor.requestTemperatures();

  //  // Get temperature in Celsius
  //  float tempC = sensor.getTempC(deviceAddress);
  //  if (PRINT_ALL) Serial.print("Temp C: ");
  //  Serial.println(tempC, 2);

  // Get temperature in Fahrenheit
  float tempF = sensor.getTempF(deviceAddress);
  if (PRINT_ALL) Serial.print("Temp F: ");
  Serial.println(tempF, 2);

  // Delay between measurements
  delay(DATA_INTERVAL);
}

// Prints device address as HEX string
void printAddress(DeviceAddress _deviceAddress)
{
  Serial.print("0x");
  for (byte i = 0; i < 8; i++)
  {
    if (_deviceAddress[i] < 16) Serial.print("0");
    Serial.print(_deviceAddress[i], HEX);
  }
}
