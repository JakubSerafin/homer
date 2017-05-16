require('normalize.css/normalize.css');
require('styles/App.css');

import React, { PropTypes }  from 'react';
import hInput from '../Primitives/hInput'

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
        // {item.id} date={item.date} value={item.value}
        super();
        this.state = {id:9,  date: Date.now(), measurmentType:1, value:0}
        
    }
    
    endEdit()
    {
        this.props.endEdit(this.state);
    }

    render()
    {
        return (
            <tr id={this.props.id}>
                <td><input value={this.state.measurmentType} onChange={(val)=>this.setState({type:val.target.value})}/></td>
                <td><input value={this.state.date} onChange={(val)=>this.setState({date:val.target.value})}/></td>
                <td><input value={this.state.value} onChange={(val)=>this.setState({value:val.target.value})}/></td>
                <td><button onClick={this.endEdit.bind(this)}>DONE</button></td>
            </tr>
       )
    }
}

export default EditRecordComponent;