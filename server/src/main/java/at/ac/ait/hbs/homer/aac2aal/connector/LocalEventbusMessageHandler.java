package at.ac.ait.hbs.homer.aac2aal.connector;

import at.ac.ait.hbs.homer.core.common.eventbus.EventbusMessage;
import at.ac.ait.hbs.homer.core.common.eventbus.EventbusMessageHandler;

/**
 * Created with IntelliJ IDEA.
 * User: graf
 * Date: 05.06.13
 * Time: 21:40
 * To change this template use File | Settings | File Templates.
 */
public class LocalEventbusMessageHandler implements EventbusMessageHandler {
    @Override
    public void handleEventbusMessage(EventbusMessage<?> eventbusMessage) {
        eventbusMessage.getSenderId();
    }
}
