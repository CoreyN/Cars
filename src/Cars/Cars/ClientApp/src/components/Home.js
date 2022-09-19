import React, { Component } from 'react';
import { Link } from "react-router-dom";

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { cars: [], loading: true };
    }

    componentDidMount() {
        this.populateCarData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <CarTable cars={this.state.cars} />;

        return (
            <div>
                <h1>Cars</h1>
                {contents}
            </div>
        );
    }

    async populateCarData() {
        const response = await fetch("api/cars");
        const data = await response.json();
        this.setState({ cars: data, loading: false});
    }
}

function CarTable(props) {
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>Make</th>
                    <th>Model</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {props.cars.map(car => <CarRow car={car} key={ car.id } />)}
            </tbody>
        </table>
    );
}

function CarRow(props, key) {
    return (
        <tr key={key}>
            <td>{props.car.make}</td>
            <td>{props.car.model}</td>
            <td> <Link to={'cars/'+props.car.id}>Stats</Link></td>
        </tr>
    );
}
