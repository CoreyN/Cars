import React, { Component } from 'react';

export class Car extends Component {
    static displayName = Car.name;

    constructor(props) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            car: {},
            loading: true
        };
    }

    componentDidMount() {
        this.populateCarData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <CarDetails car={this.state.car} />;

        return (
            <div>
                {contents}
            </div>
        );
    }

    async populateCarData() {
        const response = await fetch(`api/cars/${this.state.id}`);
        const data = await response.json();
        this.setState({ car: data, loading: false });
    }
}

function CarDetails(props) {
    return (
        <div>
            <h1>{props.car.make} {props.car.model}</h1>
            <CarTimeTable car={props.car} />
        </div>
    );
}

function CarTimeTable(props) {
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>Year</th>
                    <th>Trim</th>
                    <th>Drive</th>
                    <th>Transmission</th>
                    <th>0-60</th>
                    <th>1/4 Mile</th>
                </tr>
            </thead>
            <tbody>
                {props.car.times.map(car => <CarTimeRow car={car} key={`${car.year}-${car.trim}` } />)}
            </tbody>
        </table>
    );
}

function CarTimeRow(props, key) {
    return (
        <tr key={key}>
            <td>{props.car.year}</td>
            <td>{props.car.trim}</td>
            <td>{props.car.driveType}</td>
            <td>{props.car.transmission}</td>
            <td>{props.car.zeroToSixtyTime.toFixed(1)}s</td>
            <td>{props.car.quarterMileTime.toFixed(1)}s@{props.car.quarterMileSpeed.toFixed(1)}mph</td>
        </tr>
    );
}
