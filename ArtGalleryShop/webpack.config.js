const path = require("path");
const webpack = require('webpack');

const javaScriptTranspilerRule = {
    test: /\.js?$/,
    use: {
        loader: 'babel-loader', options: {
            presets:
                ['babel-preset-env']
        }
    }
};

const cssTranspilerRule = {
    test: /\.css$/,
    use: [{ loader: "style-loader" },
    { loader: "css-loader" }]
};

const webpackPluging = new webpack.ProvidePlugin({
    $: 'jquery',
    jQuery: 'jquery',
    'window.jQuery': 'jquery',
    Popper: ['popper.js', 'default']
});

module.exports = {
    entry: "./wwwroot/assets/js/app.js",
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js'
    },
    plugins: [webpackPluging],
    module: {
        rules: [javaScriptTranspilerRule, cssTranspilerRule]
    }
};