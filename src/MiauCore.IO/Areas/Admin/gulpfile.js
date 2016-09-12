"use strict";

const gulp = require("gulp");
const named = require("vinyl-named");
const rename = require("gulp-rename");
const webpack = require("webpack-stream");

const config = {
    output: {
        filename: "[name].js"
    },

    resolve: {
        extensions: ["", ".ts", ".tsx", ".js", ".jsx", ".json"]
    },

    module: {
        loaders: [
            { test: /\.tsx?$/, loader: "awesome-typescript-loader" }
        ]
    }
};

function TretaScript() {
    var fileDir = {};
    var tsFiles = gulp.src("./Scripts/**/*.main.ts");

    return tsFiles
        .pipe(named())
        .pipe(rename(path => fileDir[path.basename] = path.dirname))
        .pipe(webpack(config))
        .pipe(rename(path => {
            path.dirname = fileDir[path.basename];
            path.basename = path.basename.replace(".main", "");
        }))
        .pipe(gulp.dest("./Content"));
}

gulp.task("build", TretaScript);
