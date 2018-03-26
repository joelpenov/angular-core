const path = require("path");
const webpack = require("webpack");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const extractCss = new ExtractTextPlugin("bundle.css");

const javaScriptTranspilerRule = {
     test: /\.js?$/, use: { loader: "babel-loader", options: { presets: ["@babel/preset-env"] } } 
};

const cssTranspilerRule = {
    test: /\.css$/,
    use: extractCss.extract(["css-loader?minimize"])
};

const webpackPlugin = new webpack.ProvidePlugin({
    $: "jquery",
    jQuery: "jquery",
    'window.jQuery': "jquery",
    Popper: ["popper.js", "default"]
});

const urlLoaderRule = {
    test: /\.(png|woff|woff2|eot|ttf|svg)$/,
    loader: "url-loader?limit=100000"
}

module.exports = {
    entry: { main: "./wwwroot/assets/js/app.js" },
    output: {
        path: path.resolve(__dirname, "wwwroot/dist"),
        filename: "bundle.js",
        publicPath: "dist/"
    },
    plugins: [
        extractCss,
        webpackPlugin,
        new webpack.optimize.UglifyJsPlugin()
    ],
    module: {
        rules: [
            javaScriptTranspilerRule,
            cssTranspilerRule,
            urlLoaderRule
        ]
    }
};