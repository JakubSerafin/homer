require('normalize.css/normalize.css');
require('styles/App.css');

import React, { PropTypes }  from 'react';

class EditRecordComponent extends React.Component {
     static PropTypes = {
    //     date: PropTypes.string.isRequired,
    //     type: PropTypes.string,
    //     value: PropTypes.number.isRequired,
         id: PropTypes.number.isRequired,
         endEdit: PropTypes.func.isRequired
     }
    
    constructor()
    {
        super();
        this.state = {date: Date.now, type:'gówno', value:0}
        
    }
    render()
    {
        return (
            <tr id={this.props.id}>
                <td><input value={this.state.type}/></td>
                <td><input value={new Date(this.props.date).toDateString()}></input></td>
                <td><input value={this.state.value}></input></td>
                <td><button onClick={this.props.endEdit}>DONE</button></td>
            </tr>
       )
    }
}

export default EditRecordComponent;