const path = require("path");
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const extractCSS = new ExtractTextPlugin('bundle.css');

const javaScriptTranspilerRule = {
     test: /\.js?$/, use: { loader: 'babel-loader', options: { presets: ['@babel/preset-env'] } } 
};

const cssTranspilerRule = {
    test: /\.css$/,
    use: extractCSS.extract(['css-loader?minimize'])
};

const webpackPlugin = new webpack.ProvidePlugin({
    $: 'jquery',
    jQuery: 'jquery',
    'window.jQuery': 'jquery',
    Popper: ['popper.js', 'default'],    
});

module.exports = {
    entry: "./wwwroot/assets/js/app.js",
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js'
    },
    plugins: [
        extractCSS,
        webpackPlugin,
        new webpack.optimize.UglifyJsPlugin()
    ],
    module: {
        rules: [javaScriptTranspilerRule, cssTranspilerRule]
    }
};