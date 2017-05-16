import React from 'react'

class hInputComponent extends React.Component
{
    render()
    {
        return(
            
            <input value={this.prop.value} onChange={this.prop.onChange}/>
        )
    }

}

export default hInputComponent;