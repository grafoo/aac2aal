using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Stubs
{
    public class DeviceType {
	/*
	MDC_AI_TYPE_SENSOR_UNKNOWN(0, false, true, "Unknown Sensor"),							// NOT	ISO-11073 10471 conform

	MDC_AI_TYPE_SENSOR_FALL(1, true, true, "Fall sensor"),									// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_PERS(2, true, true, "Manual presence sensor (switch)"),				// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_SMOKE(3, true, true, "Smoke sensor"),								// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_CO(4, true, true, "CO sensor"),										// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_WATER(5, true, true, "Water sensor"),								// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_GAS(6, true, true, "Gas sensor"),									// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_MOTION(7, true, true, "Motion sensor"),								// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_PROPEXIT(8, true, true, "Property exit sensor"),						// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_ENURESIS(9, true, true, "Ensuresis sensor"),							// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_CONTACTCLOSURE(10, true, true, "Contact closure sensor"),			// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_USAGE(11, true, true, "Usage sensor"),								// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_SWITCH(12, true, true, "Switch sensor"),								// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_DOSAGE(13, true, true, "Dosage sensor"),								// 		ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_TEMP(14, true, true, "Temperature sensor"),							// 		ISO-11073 10471 conform
	
	MDC_AI_TYPE_SENSOR_METERING_ENERGY(15, false, true, "Energy metering sensor"),							// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_METERING_POWER(16, false, true, "Power metering sensor"),							// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_METERING_CURRENT(17, false, true, "Current metering sensor"),						// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_METERING_VOLTAGE(18, false, true, "Voltage metering sensor"),						// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_METERING_ENERGY_GENERATION(19, false, true, "Energy metering generation sensor"),	// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_METERING_POWER_GENERATION(20, false, true, "Power metering generation sensor"),		// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_METERING_CURRENT_GENERATION(21, false, true, "Current metering generation sensor"),	// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_METERING_VOLTAGE_GENERATION(22, false, true, "Voltage metering generation sensor"),	// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_BRIGHTNESS(23, false, true, "Brightness sensor"),									// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_TEMP_OUTSIDE(24, false, true, "Outside temperature sensor"),							// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_WEATHER_SUN_DIRECTION(25, false, true, "Weather - sun direction sensor"),			// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_WEATHER_WIND_DIRECTION(26, false, true, "Weather - wind direction sensor"),			// NOT	ISO-11073 10471 conform
	
	MDC_AI_TYPE_ACTUATOR_UNKNOWN(1000, false, false, "Unknown actuator"),					// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_ACTUATOR_SWITCH(1001, false, false, "Switch actuator"),						// NOT	ISO-11073 10471 conform
	MDC_AI_TYPE_ACTUATOR_DIMMER(1002, false, false, "Dimm actuator");						// NOT	ISO-11073 10471 conform
	*/
	
	public int Value { get; set; }
    public Boolean IsISOConform { get; set; }
    public Boolean IsSensor { get; set; }
    public String Title { get; set; }

	public DeviceType(int Value) {
		this.Value = Value;
	}

    public DeviceType(int Value, Boolean isISOConform)
    {
		this.Value = Value;
		this.IsISOConform = isISOConform;
	}

    public DeviceType(int Value, Boolean isISOConform, Boolean isSensor)
    {
		this.Value = Value;
		this.IsISOConform = isISOConform;
		this.IsSensor = isSensor;
	}

    public DeviceType(int Value, Boolean isISOConform, Boolean isSensor, String title)
    {
		this.Value = Value;
		this.IsISOConform = isISOConform;
		this.IsSensor = isSensor;
		this.Title = title;
	}

	

    
	

	

	
	
	
	

	
	
	

	
	
	
}
}
