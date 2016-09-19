"use strict";

const gulp = require("gulp");
const path = require("path");
const sass = require("gulp-sass");
const named = require("vinyl-named");
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

gulp.task("transpile-typescript", function () {
    var tsFiles = gulp.src("./Scripts/**/*.main.ts", { base: "./Scripts" });

    return tsFiles
        .pipe(named(function (file) {
            let filename = "";

            // Remove static path
            filename = file.path.replace(path.join(__dirname, path.normalize("./Scripts")), "");
            // Remove .main
            filename = filename.replace(".main", "");
            // Remove .ts
            filename = filename.replace(".ts", "");

            return filename;
        }))
        .pipe(webpack(config))
        .pipe(gulp.dest("./wwwroot/js"));
});

gulp.task("transpile-sass", function () {
    var sassFiles = gulp.src("./Styles/**/*.scss", { base: "./Styles" });

    return sassFiles
        .pipe(sass())
        .pipe(gulp.dest("./wwwroot/css"));
});

gulp.task("build", ["transpile-typescript", "transpile-sass"]);
