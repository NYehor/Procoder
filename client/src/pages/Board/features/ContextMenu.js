import React, { Component } from 'react'

export default class ContextMenu extends Component {
  render() {
    return (
      <div className='context-menu'>
       { this.props.render()}
      </div>
    )
  }
}
