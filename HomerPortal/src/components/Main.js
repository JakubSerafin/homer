require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import Record from './MeasurmentTable/Record'

import config from 'config'

let yeomanImage = require('../images/yeoman.png');

class AppComponent extends React.Component {
  constructor()
  {
    super();
    this.state = { items: [], types: [{id:1, name:'gaz'} ], newRow: false };
  }
  
  componentDidMount()
  {
    fetch(config.apiUrl + 'api/Measurements')
      .then(result=>result.json())
      .then(items=>this.setState({items: items}))

    fetch(config.apiUrl + 'api/Measurements/Types')
    .then(result=>result.json())
    .then(items=>this.setState({types: items}))


  }

  AddNewRow()
  {
      this.setState({newRow:true})
  }

  EndEdit(state)
  {
    this.setState({newRow:false, items: this.state.items.concat(state)});
  }

  measurmentRowClicked(record)
  {
    record.edit = !record.edit;
    let items = this.state.items;
    let itemIndex = items.findIndex(i=>i.id == record.id);
    items[itemIndex] = record;
    this.setState({items,});
  }

  newRowClick(record)
  {
      record.edit = false;
      let items = this.state.items;
      items.push(record);
      this.setState({items,newRow:false});
  }


  render() {
    var newRowBlock = null;
    let mesTyp = this.state.types.map(type=>{return {label:type.name, value:type.id}});

    if(this.state.newRow)
    {
      let newItem = {edit:this.state.newRow, date: new Date(Date.now())}
       newRowBlock = <Record record={newItem} measurmentTypes={mesTyp} onClick={this.newRowClick.bind(this)} />
    }
    else
    {
       newRowBlock = (<tr onClick={this.AddNewRow.bind(this)} ><td>Add New</td></tr>)
    }


    return (
      <div className='index'>
        <img src={yeomanImage} alt='Yeoman Generator' />
        <div className='notice'>Please edit <code>src/components/Main.js</code> to get started!</div>
        <ul>
              {this.state.types.map(type=>(<li key={type.id}>{type.name}</li>))}
        </ul>

        <table>
          <tbody>
                {newRowBlock}
              {this.state.items.map(item=><Record record={item} measurmentTypes={mesTyp} onClick={this.measurmentRowClicked.bind(this)}/>)}
            </tbody>
            </table>

      </div>
    );
  }
}


AppComponent.defaultProps = {
};

export default AppComponent;
