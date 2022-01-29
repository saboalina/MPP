/**
 * Created by grigo on 5/17/17.
 */
import React from  'react';
import './FlightsApp.css'

class FlightRow extends React.Component{

    handleClicke=(event)=>{
        console.log('delete button pentru '+this.props.flight.id);
        this.props.deleteFunc(this.props.flight.id);
    }

    render() {
        return (
            <tr>
                <td>{this.props.flight.id}</td>
                <td>{this.props.flight.destination}</td>
                <td>{this.props.flight.availableSeats}</td>
                <td><button  onClick={this.handleClicke}>Delete</button></td>
            </tr>
        );
    }
}
/*<form onSubmit={this.handleClicke}><input type="submit" value="Delete"/></form>*/
/**/
class FlightsTable extends React.Component {
    render() {
        var rows = [];
        var functieStergere=this.props.deleteFunc;
        Array.from(this.props.flights).forEach(function(flight) {
            console.log(flight);
            rows.push(<FlightRow flight={flight} key={flight.id} deleteFunc={functieStergere} />);
        });
        return (<div className="FlightsTable">

            <table className="center">
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Destination</th>
                    <th>Available Seats</th>

                    <th>
                    </th>
                </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>

            </div>
        );
    }
}

export default FlightsTable;