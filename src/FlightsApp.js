/**
 * Created by grigo on 5/18/17.
 */
import React from  'react';
import FlightsTable from './FlightsTable';
import './FlightsApp.css'
import FlightForm from "./FlightForm";
import {GetFlights, DeleteFlight, AddFlight, UpdateFlight} from './utils/rest-calls'


class FlightsApp extends React.Component{
    constructor(props){
        super(props);
        this.state={flights:[{"flightID":"1","destination":"a","departureDate":"2021", "departureTime":"20", "airport":"b", "availableSeats":"65"}],
            deleteFunc:this.deleteFunc.bind(this),
            addFunc:this.addFunc.bind(this),
            updateFunc:this.updateFunc.bind(this)
        }
        console.log('FlightsApp constructor')
    }

    addFunc(flight){
        console.log('inside add Func '+flight);
        AddFlight(flight)
            .then(res=> GetFlights())
            .then(flights=>this.setState({flights}))
            .catch(error=>console.log('eroare add ',error));
    }


    deleteFunc(flight){
        console.log('inside deleteFunc '+flight);
        DeleteFlight(flight)
            .then(res=> GetFlights())
            .then(flights=>this.setState({flights}))
            .catch(error=>console.log('eroare delete', error));
    }

    updateFunc(flight){
        console.log('inside add Func '+flight);
        UpdateFlight(flight)
            .then(res=> GetFlights())
            .then(flights=>this.setState({flights}))
            .catch(error=>console.log('eroare add ',error));
    }


    componentDidMount(){
        console.log('inside componentDidMount')
        GetFlights().then(flights=>this.setState({flights}));
    }

    render(){
        return(
            <div className="FlightsApp">
                <h1>Flight</h1>
                <FlightForm addFunc={this.state.addFunc} updateFunc={this.state.updateFunc}/>
                <br/>
                <br/>
                 <FlightsTable flights={this.state.flights} deleteFunc={this.state.deleteFunc}/>
            </div>
        );
    }
}

export default FlightsApp;