package at.ac.ait.hbs.homer.aac2aal.connector;

import at.ac.ait.hbs.homer.core.common.eventbus.EventbusConnector;
import at.ac.ait.hbs.homer.core.common.eventbus.EventbusMessage;
import at.ac.ait.hbs.homer.core.common.homecontrol.HomeControlCommand;
import at.ac.ait.hbs.homer.core.common.homecontrol.enumerations.Command;

/**
 * Created with IntelliJ IDEA.
 * User: graf
 * Date: 05.06.13
 * Time: 21:41
 * To change this template use File | Settings | File Templates.
 */
public class LocalEventbusClient {
    private String replyAddress = "AAC2AALEventbusConnector";
    private LocalEventbusMessageHandler eventbusMessageHandler = new LocalEventbusMessageHandler();
    private LocalEventbusConnector eventbusConnector = new LocalEventbusConnector();

    public final void register() {
        eventbusConnector.register("asdf", replyAddress, eventbusMessageHandler);
    }

    public final void unregister() {
        eventbusConnector.unregister("asdf", replyAddress, eventbusMessageHandler);
    }

    public void requestFlatConfig(String senderID) {
        EventbusMessage<HomeControlCommand> eventbusMessage = new EventbusMessage<HomeControlCommand>();
        HomeControlCommand homeControlCommand = new HomeControlCommand(Command.REQUEST_FLAT_CONFIG);
        eventbusMessage.setBody(homeControlCommand);
        eventbusMessage.setAddress("homecontrol");
        eventbusMessage.setSenderId(senderID);
        eventbusMessage.setReplyAddress(replyAddress);
        eventbusMessage.setMode(EventbusMessage.PUBLISH);
        eventbusConnector.publish(eventbusMessage);
    }
}
