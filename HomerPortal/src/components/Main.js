require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import Record from './Record'
let yeomanImage = require('../images/yeoman.png');

class AppComponent extends React.Component {
  constructor()
  {
    super();
    this.state = { items: [], types: [] };
  }
  
  componentDidMount()
  {
    fetch('http://homerapp.azurewebsites.net/api/Measurements')
    .then(result=>result.json())
    .then(items=>this.setState({items}))
  }

  render() {
    return (
      <div className='index'>
        <img src={yeomanImage} alt='Yeoman Generator' />
        <div className='notice'>Please edit <code>src/components/Main.js</code> to get started!</div>
        <ul>
              {this.state.items.map(item=><Record id={item.id} date={item.date} value={item.value} type={item.measurmentType}/>)}
        </ul>
      </div>
    );
  }
}

AppComponent.defaultProps = {
};

export default AppComponent;
