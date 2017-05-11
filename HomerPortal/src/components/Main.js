require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import Record from './Record'
let yeomanImage = require('../images/yeoman.png');

class AppComponent extends React.Component {
  constructor()
  {
    super();
    this.state = { items: [], types: [{id:1, name:'gaz'}] };
  }
  
  componentDidMount()
  {
    fetch('http://localhost:50260/api/Measurements')
    .then(result=>result.json())
    .then(items=>this.setState({items: items}))

        fetch('http://localhost:50260/api/Measurements/Types')
    .then(result=>result.json())
    .then(items=>this.setState({types: items}))


  }

  render() {
    return (
      <div className='index'>
        <img src={yeomanImage} alt='Yeoman Generator' />
        <div className='notice'>Please edit <code>src/components/Main.js</code> to get started!</div>
        <ul>
              {this.state.types.map(type=>(<li key={type.id}>{type.name}</li>))}
        </ul>
        <ul>
              {this.state.items.map(item=><Record id={item.id} date={item.date} value={item.value} type={this.state.types.find(_=>_.id==item.measurmentType).name}/>)}
        </ul>

      </div>
    );
  }
}

AppComponent.defaultProps = {
};

export default AppComponent;
