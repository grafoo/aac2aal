using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Stubs
{
    class HomeControlCommand
    {


	private Command command;

	private DeviceMessageType msgType;

	private int deviceId;
	
	private int value;

	/**
	 * Creating a HomeControlCommand.
	 * @param command - The command
	 * @param deviceId - The internal id of the device
	 * @param msgType - The ISO 11073 conform type of the message
	 * 
	 */
	
	public HomeControlCommand(Command command, int deviceId, DeviceMessageType msgType) {
		this.command = command;
		this.deviceId = deviceId;
		this.msgType = msgType;
	}

	
	/**
	 * Creating a HomeControlCommand.
	 * @param command - The command
	 * @param deviceId - The internal id of the device
	 * @param msgType - The ISO 11073 conform type of the message
	 * @param value - Optionally, a value can be set, e.g. the dimm value of a dimm actuator
	 * 
	 */
	
	public HomeControlCommand(Command command, int deviceId, DeviceMessageType msgType, int value) {
		this.command = command;
		this.deviceId = deviceId;
		this.msgType = msgType;
		this.value = value;
	}
	
	/*
	public HomeControlCommand( Command command) {
		this(command, null, null);
	}*/

	public  Command getCommand() {
		return this.command;
	}

	public  DeviceMessageType getDeviceMessageType() {
		return this.msgType;
	}

	public  int getDeviceId() {
		return this.deviceId;
	}
	
	public  int getValue() {
		return this.value;
	}

}
    }

