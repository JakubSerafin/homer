require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import Record from './MeasurmentTable/Record'
import EditRecord from './MeasurmentTable/EditRecord'

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

    fetch(config.apiUrl + '/api/Measurements/Types')
    .then(result=>result.json())
    .then(items=>this.setState({types: items}))


  }

  AddNewRow()
  {
      this.setState((s)=>s={newRow:true})
  }

  EndEdit()
  {
    this.setState((s)=>s={newRow:false})
  }

  render() {
    var newRowBlock = null;
    if(this.state.newRow)
    {
       newRowBlock = <EditRecord id={666} endEdit={this.EndEdit.bind(this)} />
    }
    else
    {
       newRowBlock = (<tr onClick={this.AddNewRow.bind(this)} >Add New</tr>)
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
                {this.state.items.map(item=><Record id={item.id} date={item.date} value={item.value} type={this.state.types.find(_=>_.id==item.measurmentType).name}/>)}
        
       
            </tbody>
            </table>

      </div>
    );
  }
}

AppComponent.defaultProps = {
};

export default AppComponent;
