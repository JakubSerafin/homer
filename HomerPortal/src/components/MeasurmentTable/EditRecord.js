require('normalize.css/normalize.css');
require('styles/App.css');

import React, { PropTypes }  from 'react';
import Dropdown from 'react-dropdown'

class EditRecordComponent extends React.Component {
     static PropTypes = {
    //     date: PropTypes.string.isRequired,
    //     type: PropTypes.string,
    //     value: PropTypes.number.isRequired,
        // id: PropTypes.number.isRequired,
        // endEdit: PropTypes.func.isRequired
     }
    
    constructor(props)
    {
        // {item.id} date={item.date} value={item.value}
        super(props);
        this.state = {id:9,  date: Date.now(), measurmentType:this.props.measurmentTypes[0], value:0}
        this._onSelect = this._onSelect.bind(this);
    }

    _onSelect(option)
    {
        this.setState({selectedMeasurmentType:option, measurmentType:option.value});
    }
    
    endEdit()
    {
        this.props.endEdit(this.state);
    }

    //const defaultOption = options[0]

    render()
    {
        let mappedMeasurments = this.props.measurmentTypes.map(type=>{return {label:type.name, value:type.id}});
        
        return (
            <tr id={this.props.id}>
                <td><Dropdown options={mappedMeasurments} onChange={this._onSelect} value={this.state.selectedMeasurmentType} placeholder="Select an option" /></td>
                <td><input value={this.state.date} onChange={(val)=>this.setState({date:val.target.value})}/></td>
                <td><input value={this.state.value} onChange={(val)=>this.setState({value:val.target.value})}/></td>
                <td><button onClick={this.endEdit.bind(this)}>DONE</button></td>
            </tr>
       )
    }
}

export default EditRecordComponent;