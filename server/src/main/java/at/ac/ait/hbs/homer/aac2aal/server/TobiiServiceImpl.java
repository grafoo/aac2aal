package at.ac.ait.hbs.homer.aac2aal.server;

import at.ac.ait.hbs.homer.aac2aal.api.TobiiService;

import javax.jws.WebService;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

/**
 * Created with IntelliJ IDEA.
 * User: graf
 * Date: 30.05.13
 * Time: 21:46
 * To change this template use File | Settings | File Templates.
 */

@Produces(MediaType.APPLICATION_JSON)
@WebService
public class TobiiServiceImpl implements TobiiService {
    @Override
    @GET
    @Path("/flat")
    public String getFlatConfig() {
        return "Flatconfig";
    }
}
