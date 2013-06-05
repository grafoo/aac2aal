package at.ac.ait.hbs.homer.aac2aal.connector;

import at.ac.ait.hbs.homer.core.common.eventbus.EventbusConnector;
import at.ac.ait.hbs.homer.core.common.eventbus.EventbusMessage;
import at.ac.ait.hbs.homer.core.common.eventbus.EventbusMessageHandler;
import at.ac.ait.hbs.homer.core.common.homecontrol.HomeControlCommand;
import at.ac.ait.hbs.homer.core.common.homecontrol.enumerations.Command;

/**
 * Created with IntelliJ IDEA.
 * User: graf
 * Date: 05.06.13
 * Time: 03:40
 * To change this template use File | Settings | File Templates.
 */
public class LocalEventbusConnector implements EventbusConnector {
    @Override
    public void send(EventbusMessage<?> eventbusMessage) {
        //To change body of implemented methods use File | Settings | File Templates.
    }

    @Override
    public void publish(EventbusMessage<?> eventbusMessage) {
        //To change body of implemented methods use File | Settings | File Templates.
    }

    @Override
    public void register(String s, String s2, EventbusMessageHandler eventbusMessageHandler) {
        //To change body of implemented methods use File | Settings | File Templates.
    }

    @Override
    public void unregister(String s, String s2, EventbusMessageHandler eventbusMessageHandler) {
        //To change body of implemented methods use File | Settings | File Templates.
    }
}
