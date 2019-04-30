const path = require('path');
console.log(__dirname);
module.exports = {
  entry: {
    bundle: './src/index.js'
  },
  output: {
    path: path.resolve(__dirname, './build'),
    filename: './js/[name].js',
    publicPath: ''
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: {
            presets: ['@babel/env', '@babel/preset-react']
          }
        }
      },
      {
        test: /\.scss|sass$/,
        use: ['style-loader', 'css-loader', 'sass-loader']
      }
    ]
  },
  resolve: {
    modules: [path.resolve('./node_modules')]
  },
  devServer: {
    port: 8080,
    contentBase: path.resolve(__dirname, './'),
    historyApiFallback: true
  },
  devtool: 'source-map'
};