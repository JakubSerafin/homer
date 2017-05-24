require('normalize.css/normalize.css');
require('styles/App.css');

import React, { PropTypes }  from 'react';
import Dropdown from 'react-dropdown'
import {Button} from 'reactstrap'

class RecordComponent extends React.Component {
    
    mappedMeasurments
    constructor(props)
    {
        super(props);
        this.state = {
            value: this.props.record.value,
            measurmentType:this.props.record.measurmentType,
            date:this.props.record.date,
            edit:this.props.record.edit
        }
    }

    _onSelect(option)
    {
        this.setState({measurmentType:option.value});
    }

    mapMeasurmentType(measurmentTypeId,types){
        return types.find(m=>m.value===measurmentTypeId);
    }

    _onStateChange()
    {

        this.props.onClick({value:this.state.value, date:this.state.date, edit:this.props.record.edit, measurmentType:this.state.measurmentType, id:this.props.record.id});
    }


    render()
    {
        if(this.props.record.edit===true)
        {
            let selectedMeasurmentType = this.mapMeasurmentType(this.state.measurmentType,this.props.measurmentTypes);
            return(
            <tr  className={'record editRecord'} id={this.props.id}>
                <td><Dropdown options={this.props.measurmentTypes} onChange={this._onSelect.bind(this)} value={selectedMeasurmentType} placeholder="Select an option" /></td>
                <td><input value={this.state.date} onChange={(val)=>this.setState({date:val.target.value})}/></td>
                <td><input value={this.state.value} onChange={(val)=>this.setState({value:val.target.value})}/></td>
                <td><Button onClick={this._onStateChange.bind(this)}>DONE</Button></td>
            </tr>
            )
        }
        else
        {
            return (
                <tr className={'record'} id={this.props.record.id} onClick={this._onStateChange.bind(this)}>
                    <td>{this.props.record.measurmentType}</td>
                    <td>{new Date(this.props.record.date).toDateString()}</td>
                    <td>{this.props.record.value}</td>
                    <td></td>
                </tr>
            )
        }
    }
}

export default RecordComponent;