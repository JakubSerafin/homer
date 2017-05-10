require('normalize.css/normalize.css');
require('styles/App.css');

import React, { PropTypes }  from 'react';

let yeomanImage = require('../images/yeoman.png');

class RecordComponent extends React.Component {
    static PropTypes = {
        date: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        value: PropTypes.number.isRequired,
        id: PropTypes.number.isRequired
    }
    
    constructor()
    {
        super();
        
    }
    render()
    {
        return (
        <li key={this.props.id}>date: {this.props.date}, type:{this.props.measurmentType}, value: {this.props.value}></li>
       )
    }
}

export default RecordComponent;