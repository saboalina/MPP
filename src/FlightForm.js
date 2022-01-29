/**
 * Created by grigo on 5/19/17.
 */
import React from  'react';
class FlightForm extends React.Component{

    constructor(props) {
        super(props);
        this.state = {flightID: '', destination:'', departureDate:'',departureTime:'', airport:'', availableSeats:''};

    }

    handleIDChange=(event) =>{
        this.setState({flightID: event.target.value});
    }

    handleDestinationChange=(event) =>{
        this.setState({destination: event.target.value});
    }

    handleDepartureDateChange=(event) =>{
        this.setState({departureDate: event.target.value});
    }
    handleDepartureTimeChange=(event) =>{
        this.setState({departureTime: event.target.value});
    }

    handleAirportChange=(event) =>{
        this.setState({airport: event.target.value});
    }

    handleAvailableSeatsChange=(event) =>{
        this.setState({availableSeats: event.target.value});
    }
    handleSubmit =(event) =>{

        var flight={id:this.state.flightID,
                destination:this.state.destination,
                departureDate:this.state.departureDate,
                departureTime:this.state.departureTime,
                airport:this.state.airport,
                availableSeats:this.state.availableSeats,

        }
        console.log('A flight was submitted: ');
        console.log(flight);
        this.props.addFunc(flight);
        event.preventDefault();
    }
    handleUpdate=(event) =>{

        var flight={id:this.state.flightID,
            destination:this.state.destination,
            departureDate:this.state.departureDate,
            departureTime:this.state.departureTime,
            airport:this.state.airport,
            availableSeats:this.state.availableSeats,

        }
        console.log('A flight was submitted: ');
        console.log(flight);
        this.props.updateFunc(flight);
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    ID:
                    <input type="text" value={this.state.flightID} onChange={this.handleIDChange} />
                </label><br/>
                <label>
                    Destination:
                    <input type="text" value={this.state.destination} onChange={this.handleDestinationChange} />
                </label><br/>
                <label>
                    Departure Date:
                    <input type="text" value={this.state.departureDate} onChange={this.handleDepartureDateChange} />
                </label><br/>
                <label>
                    Departure Time:
                    <input type="text" value={this.state.departureTime} onChange={this.handleDepartureTimeChange} />
                </label><br/>
                <label>
                    Airport:
                    <input type="text" value={this.state.airport} onChange={this.handleAirportChange} />
                </label><br/>
                <label>
                    Available Seats:
                    <input type="text" value={this.state.availableSeats} onChange={this.handleAvailableSeatsChange} />
                </label><br/>

                <input type="submit" value="Submit" />
                <button onClick={this.handleUpdate}>Update</button>
            </form>
        );
    }
}
export default FlightForm;