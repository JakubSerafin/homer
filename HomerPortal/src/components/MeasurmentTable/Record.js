require('normalize.css/normalize.css');
require('styles/App.css');

import React, { PropTypes }  from 'react';

class RecordComponent extends React.Component {
    static PropTypes = {
        date: PropTypes.string.isRequired,
        type: PropTypes.string,
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
            <tr id={this.props.id}>
                <td>{this.props.type}</td>
                <td>{new Date(this.props.date).toDateString()}</td>
                <td>{this.props.value}</td>
            </tr>
       )
    }
}

export default RecordComponent;