var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var helpers = require('./helpers');
var bootstrapEntryPoints = require('./webpack.bootstrap.config');
var isProd = process.env.NODE_ENV === 'production';
var bootstrapConfig = isProd ? bootstrapEntryPoints.prod: bootstrapEntryPoints.dev;

module.exports = {
    entry: {
        'polyfills': './config/polyfills.ts',
        'vendors': './config/vendors.ts',
        'app': './app/main.ts',
        'bootstrap': bootstrapConfig
    },

    resolve: {
        extensions: ['.ts', '.js'] // Try .ts first, otherwise map will reference .js file.
    },

    module: {
        rules: [
            {
                test: /\.ts$/,
                use: [
                    { loader: 'awesome-typescript-loader' },
                    { loader: 'angular2-template-loader' }
                ]
            },
            {
                test: /\.html$/,
                use: { loader: 'html-loader' }
            },
            {
                test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
                use: {
                    loader: 'file-loader',
                    options: {
                        name: 'assets/[name].[hash].[ext]'
                    }
                }
            },
            {
                test: /\.css$/,
                use: ['to-string-loader', 'css-loader'],
                exclude: [helpers.root('src', 'app')]
            },
            {
                test: /\.scss$/,
                use: ['to-string-loader', 'css-loader', 'sass-loader'],
                exclude: [helpers.root('src', 'app')]
            },
            {
                test: /bootstrap-sass[\/\\]assets[\/\\]javascripts[\/\\]/,
                use: 'imports-loader?jQuery=jquery'
            }
        ]
    },

    plugins: [
        new webpack.optimize.CommonsChunkPlugin({
            name: ['app', 'vendor', 'polyfills']
        }),

        new webpack.ContextReplacementPlugin(
            /angular(\\|\/)core(\\|\/)@angular/,
            __dirname
        ),

        new HtmlWebpackPlugin({
            template: './index.html'
        }),

        new webpack.ProvidePlugin({
            jQuery: 'jquery',
            $: 'jquery',
            jquery: 'jquery'
        })
    ]
};