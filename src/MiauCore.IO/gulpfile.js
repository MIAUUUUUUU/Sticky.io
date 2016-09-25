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

    function keepDir(baseDir = "./Scripts", ext = /\.tsx?$/, suffix = /\.main$/) {
        baseDir = path.normalize(`${__dirname}/${path.normalize(baseDir)}`);

        return function (file) {
            var filename = "";

            // Remove static path
            filename = file.path.replace(baseDir, "");
            filename = filename.replace(ext, "");
            filename = filename.replace(suffix, "");

            return path.posix.normalize(filename);
        };
    }

    return tsFiles
        .pipe(named(keepDir()))
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
