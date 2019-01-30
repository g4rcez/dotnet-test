import React, { Component } from "react";
import axios from "axios";
import "./App.css";

const api = "http://localhost:5000/api";

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      list: [],
      lates: 0,
      inProgress: 0,
      total: []
    };
  }

  filterStatus = (arr, status) => arr.filter(x => x.status.id === status);

  setFromResponse = res => {
    this.setState({
      total: res.data,
      list: res.data,
      inProgress: this.filterStatus(res.data, 1).length,
      lates: this.filterStatus(res.data, 2).length
    });
  };

  getList = () => {
    axios
      .get(api)
      .then(res => {
        console.log(res.data);
        this.setFromResponse(res);
      })
      .catch(e => console.log(e));
  };

  async componentDidMount() {
    await this.getList();
  }

  requestOrder = () => {
    axios.get(`${api}/orderByEmail`).then(res => this.setFromResponse(res));
  };

  render() {
    return (
      <React.Fragment>
        <div className="sidenav">
          <hr />
          <a className="tarja selected">
            EM ANDAMENTO
            <span className="badge badge-pill badge-andamento">
              <div id="contador">{this.state.inProgress}</div>
            </span>
          </a>
          <hr />
          <a className="tarja">
            ATRASADAS
            <span className="badge badge-pill badge-atrasadas">
              {this.state.lates}
            </span>
          </a>
          <hr />
          <a className="tarja">ITEM</a>
          <hr />
          <a className="tarja">ITEM</a>
          <hr />
        </div>
        <div className="main">
          <hr />
          <h1 className="titulo">
            Em andamento
            <button
              type="button"
              className="btn btn-primary pull-right"
              id="cadastrar"
              onClick={this.requestOrder}
            >
              Cadastrar lorem
            </button>
          </h1>
          <hr />
          <table className="table table-striped table-hover">
            <tbody>
              {this.state.list.map(props => {
                return (
                  <tr>
                    <td>
                      <input
                        class="form-check-input"
                        type="checkbox"
                        value=""
                      />
                    </td>
                    <td>{props.name}</td>
                    <td>
                      <a href={`mailto:${props.email}`}>{props.email}</a>
                    </td>
                    <td />
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </React.Fragment>
    );
  }
}

export default App;
