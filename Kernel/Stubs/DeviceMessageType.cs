using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Kernel.Stubs
{
   public class DeviceMessageType {
	
	
	MDC_AI_FLAG_SENSOR_HEALTH_AUTO_PRESENCE_RECEIVED(null, 16, "auto-presence-received"),	//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_HEALTH_AUTO_PRESENCE_FAILED(null, 17, "auto-presence-failed"),		//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_HEALTH_LOW_BATTERY(null, 18, "low-battery"),							//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_HEALTH_FAULT(null, 19, "fault"),										//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_HEALTH_END_OF_LIFE(null, 20, "end-of-life"),							//		ISO-11073 10471 conform
	*/
	
    /*
	MDC_AI_FLAG_SENSOR_FALL_DETECTED(1, DeviceType.MDC_AI_TYPE_SENSOR_FALL, 0, "fall-detected"),							//		ISO-11073 10471 conform
	
	MDC_AI_FLAG_SENSOR_PERS_ACTIVATED(2, DeviceType.MDC_AI_TYPE_SENSOR_PERS, 0, "pers-activated"),							//		ISO-11073 10471 conform
	
	MDC_AI_FLAG_SENSOR_CONDITION_DETECTED(3, 0, "condition-detected",														//		ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_SENSOR_SMOKE,
			DeviceType.MDC_AI_TYPE_SENSOR_CO,
			DeviceType.MDC_AI_TYPE_SENSOR_WATER,
			DeviceType.MDC_AI_TYPE_SENSOR_GAS),

    MDC_AI_FLAG_SENSOR_MOTION_DETECTED(4, DeviceType.MDC_AI_TYPE_SENSOR_MOTION, 0, "motion-detected"),						//		ISO-11073 10471 conform
    MDC_AI_FLAG_SENSOR_MOTION_DETECTED_DELAYED(5, DeviceType.MDC_AI_TYPE_SENSOR_MOTION, 1, "motion-detected-delayed"),		//		ISO-11073 10471 conform
    MDC_AI_FLAG_SENSOR_MOTION_TAMPER_DETECTED(6, DeviceType.MDC_AI_TYPE_SENSOR_MOTION, 2, "tamper-detected"),				//		ISO-11073 10471 conform
    MDC_AI_FLAG_SENSOR_MOTION_NO_MOTION_DETECTED(24, DeviceType.MDC_AI_TYPE_SENSOR_MOTION, 3, "nomotion-detected", false),	// NOT	ISO-11073 10471 conform

	MDC_AI_FLAG_SENSOR_PROPEXIT_OCCUPANT_EXIT(7, DeviceType.MDC_AI_TYPE_SENSOR_PROPEXIT, 0, "occupant-exit-property"),		//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_PROPEXIT_EXIT_DOOR_LEFT_OPEN(8, DeviceType.MDC_AI_TYPE_SENSOR_PROPEXIT, 1, "exit-door-left-open"),	//		ISO-11073 10471 conform
	
	MDC_AI_FLAG_SENSOR_ENURESIS_DETECTED(9, DeviceType.MDC_AI_TYPE_SENSOR_ENURESIS, 0, "enuresis-detected"),				//		ISO-11073 10471 conform

	MDC_AI_FLAG_SENSOR_CONTACTCLOSURE_OPENED(10, DeviceType.MDC_AI_TYPE_SENSOR_CONTACTCLOSURE, 0, "contact-opened"),		//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_CONTACTCLOSURE_CLOSED(11, DeviceType.MDC_AI_TYPE_SENSOR_CONTACTCLOSURE, 1, "contact-closed"),		//		ISO-11073 10471 conform

	MDC_AI_FLAG_SENSOR_USAGE_STARTED(12, DeviceType.MDC_AI_TYPE_SENSOR_USAGE, 0, "usage-started"),							//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_USAGE_USAGE_ENDED(13, DeviceType.MDC_AI_TYPE_SENSOR_USAGE, 1, "usage-ended"),						//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_USAGE_EXPECTED_USE_START_VIOLATION(14, DeviceType.MDC_AI_TYPE_SENSOR_USAGE, 2, "expected-use-start-violation"),	//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_USAGE_EXPECTED_USE_STOP_VIOLATION(15, DeviceType.MDC_AI_TYPE_SENSOR_USAGE, 3, "expected-use-stop-violation"),	//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_USAGE_ABSENCE_VIOLATION(16, DeviceType.MDC_AI_TYPE_SENSOR_USAGE, 4, "absence-violation"),			//		ISO-11073 10471 conform

	// TODO shouldn't there be a separate message for actuators? (JK)
	MDC_AI_FLAG_SENSOR_SWITCH_ON(17, 0, "switch-on",
			DeviceType.MDC_AI_TYPE_SENSOR_SWITCH,																			// 		ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_ACTUATOR_SWITCH),																		// NOT	ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_SWITCH_OFF(18, 1, "switch-off",
			DeviceType.MDC_AI_TYPE_SENSOR_SWITCH,																			// 		ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_ACTUATOR_SWITCH),																		// NOT	ISO-11073 10471 conform

	MDC_AI_FLAG_SENSOR_DOSAGE_TAKEN(19, DeviceType.MDC_AI_TYPE_SENSOR_DOSAGE, 0, "dosage-taken"),							//		ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_DOSAGE_MISSED(20, DeviceType.MDC_AI_TYPE_SENSOR_DOSAGE, 1, "dosage-missed"),							//		ISO-11073 10471 conform
	
	MDC_AI_FLAG_SENSOR_TEMP_HIGH_TEMPERATURE_DETECTED(21, 0, "high-temperature-detected",
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP,																				//		ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP_OUTSIDE),																	// NOT	ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_TEMP_LOW_TEMPERATURE_DETECTED(22, 1, "low-temperature-detected",
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP,																				//		ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP_OUTSIDE),																	// NOT	ISO-11073 10471 conform
	MDC_AI_FLAG_SENSOR_TEMP_RATE_OF_CHANGE_TOO_FAST(23, 2, "rate-of-change-too-fast",
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP,																				//		ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP_OUTSIDE),																	// NOT	ISO-11073 10471 conform

	MDC_AI_FLAG_SENSOR_METERING_READING(25, 0, "meter-reading", false,														// NOT	ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_ENERGY,
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_POWER,
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_CURRENT,
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_VOLTAGE,
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_ENERGY_GENERATION,
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_POWER_GENERATION,
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_CURRENT_GENERATION,
			DeviceType.MDC_AI_TYPE_SENSOR_METERING_VOLTAGE_GENERATION),

	MDC_AI_FLAG_SENSOR_NO_CONDITION_DETECTED(26, 1, "no-condition-detected",												//		ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_SENSOR_FALL,
			DeviceType.MDC_AI_TYPE_SENSOR_PERS,
			DeviceType.MDC_AI_TYPE_SENSOR_SMOKE,
			DeviceType.MDC_AI_TYPE_SENSOR_CO,
			DeviceType.MDC_AI_TYPE_SENSOR_WATER,
			DeviceType.MDC_AI_TYPE_SENSOR_GAS,
			DeviceType.MDC_AI_TYPE_SENSOR_MOTION,
			DeviceType.MDC_AI_TYPE_SENSOR_PROPEXIT,
			DeviceType.MDC_AI_TYPE_SENSOR_ENURESIS,
			DeviceType.MDC_AI_TYPE_SENSOR_CONTACTCLOSURE,
			DeviceType.MDC_AI_TYPE_SENSOR_USAGE,
			DeviceType.MDC_AI_TYPE_SENSOR_SWITCH,
			DeviceType.MDC_AI_TYPE_SENSOR_DOSAGE,
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP,
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP_OUTSIDE),

	MDC_AI_FLAG_SENSOR_TEMPERATURE_READING(27, 0, "temperature-reading", false,												// NOT	ISO-11073 10471 conform
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP,
			DeviceType.MDC_AI_TYPE_SENSOR_TEMP_OUTSIDE),

	// TODO: is there an iso-conform value for actuator switch and dimm messages??? (JK)
	MDC_AI_FLAG_ACTUATOR_DIMM_ABSOLUTE(30, 0, "dimm absolute", false, DeviceType.MDC_AI_TYPE_ACTUATOR_DIMMER);
	*/
	/*
	// TODO Add missing flags for custom devices
	MDC_AI_TYPE_SENSOR_BRIGHTNESS(23), // NOT ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_WEATHER_SUN_DIRECTION(25), // NOT ISO-11073 10471 conform
	MDC_AI_TYPE_SENSOR_WEATHER_WIND_DIRECTION(26), // NOT ISO-11073 10471 conform
	*/
       
/*
	private int id;
	private List<DeviceType> types;
	private int value;
	private String name;
	private Boolean isISOConform = true;
	
	private DeviceMessageType( int id,  DeviceType deviceType,  int value,  String name) {
		List<DeviceType> types = new List<DeviceType>();
		types.Add(deviceType);
		
		this.id = id;
		this.types = System.Collections.(types);
		this.value = value;
		this.name = name;
	}
	
	private DeviceMessageType( int id,  List<DeviceType> deviceTypes,  int value,  String name) {
		this.id = id;
		this.types = deviceTypes;
		this.value = value;
		this.name = name;
	}
	
	private DeviceMessageType( int id,  int value,  String name,  DeviceType... deviceTypes) {
		List<DeviceType> types = new ArrayList<DeviceType>();
		for (DeviceType type : deviceTypes) {
			types.add(type);
		}

		this.id = id;
		ReadOnlyCollection<DeviceType> (this.types) = Collections.unmodifiableList(types);
		this.value = value;
		this.name = name;
	}
	
	private DeviceMessageType( int id,  DeviceType deviceType,  int value,  String name,  Boolean isISOConform) {
		List<DeviceType> types = new ArrayList<DeviceType>();
		types.add(deviceType);

		this.id = id;
		this.types = Collections.unmodifiableList(types);
		this.value = value;
		this.name = name;
		this.isISOConform = isISOConform;
	}
	
	private DeviceMessageType( int id,  List<DeviceType> deviceTypes,  int value,  String name,  Boolean isISOConform) {
		this.id = id;
		this.types = Collections.unmodifiableList(deviceTypes);
		this.value = value;
		this.name = name;
		this.isISOConform = isISOConform;
	}
	
	private DeviceMessageType( int id,  int value,  String name,  Boolean isoConform,  DeviceType... deviceTypes) {
		List<DeviceType> types = new ArrayList<DeviceType>();
		for (DeviceType type : deviceTypes) {
			types.add(type);
		}

		this.id = id;
		this.types = Collections.unmodifiableList(types);
		this.value = value;
		this.name = name;
		this.isISOConform = isoConform;
	}

	public int getId() {
		return id;
	}

	public List<DeviceType> getTypes() {
		return types;
	}

	public int getValue() {
		return value;
	}

	public String getName() {
		return name;
	}

	public Boolean isISOConform() {
		return isISOConform;
	}
	
	public static DeviceMessageType getFlagForId( int id) {
		for (DeviceMessageType item : values()) {
            if (item.getId().equals(id)) {
                return item;
            }
        }
		
	    return null;
	}
	
	public static DeviceMessageType getFlag( DeviceType type,  String name) {
	    List<DeviceMessageType> flags = getFlagsForDeviceType(type);
		
		for (DeviceMessageType item : flags) {
	        if (item.getName().equals(name)) {
	        	return item;
	        }
	    }
		
	    return null;
	}
	
	public static DeviceMessageType getFlag( DeviceType type,  int value) {
	    List<DeviceMessageType> flags = getFlagsForDeviceType(type);

	    if (flags.size() == 1) {
	    	return flags.get(0);
	    } else if (flags.size() > 0) {
	    	for (DeviceMessageType item : flags) {
	    		if (item.getValue().equals(value)) {
	    			return item;
	    		}
	    	}
	    }
	    return null;
	}
	
	public static List<DeviceMessageType> getFlags() {
	    return Collections.unmodifiableList(Arrays.asList(values()));
	}
	
	public static List<DeviceMessageType> getFlagsForDeviceType( DeviceType type) {
	    List<DeviceMessageType> flags = new ArrayList<DeviceMessageType>();
		
		for (DeviceMessageType flag : values()) {
	        if (flag.getTypes().contains(type)) {
	        	flags.add(flag);
	        }
	    }
		
	    return Collections.unmodifiableList(flags);
	}
	
	public static List<DeviceMessageType> getFlagsForValue( int value) {
	    List<DeviceMessageType> flags = new ArrayList<DeviceMessageType>();
		
		for (DeviceMessageType flag : values()) {
	        if (flag.getValue().equals(value)) {
	        	flags.add(flag);
	        }
	    }
		
	    return Collections.unmodifiableList(flags);
	}
	
	public static List<DeviceMessageType> getFlagsForName( String name) {
	    List<DeviceMessageType> flags = new ArrayList<DeviceMessageType>();
		
		for (DeviceMessageType flag : values()) {
	        if (flag.getName().equals(name)) {
	        	flags.add(flag);
	        }
	    }
		
	    return Collections.unmodifiableList(flags);
	}
	
	public static List<DeviceMessageType> getFlagsForISOConformity( Boolean isoConform) {
	    List<DeviceMessageType> flags = new ArrayList<DeviceMessageType>();
		
		for (DeviceMessageType flag : values()) {
	        if (flag.isISOConform().equals(isoConform)) {
	        	flags.add(flag);
	        }
	    }
		
	    return Collections.unmodifiableList(flags);
	}
	
	public static boolean isSupported( DeviceType deviceType,  int value) {
		List<DeviceMessageType> flags = getFlagsForDeviceType(deviceType);
		
		for (DeviceMessageType item : flags) {
			if (item.getValue().equals(value)) {
				return true;
			}
		}
		return false;
	}
	
	public static boolean isSupported( DeviceType deviceType,  String name) {
		List<DeviceMessageType> flags = getFlagsForDeviceType(deviceType);
		
		for (DeviceMessageType item : flags) {
			if (item.getName().equals(name)) {
				return true;
			}
		}
		return false;
	}
	
	@Override
	public String toString() {
		return this.name();
	}
}

}
/*