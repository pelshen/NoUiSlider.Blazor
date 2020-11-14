var gulp = require('gulp');
var concat = require('gulp-concat');
var minify = require('gulp-minify');
var cleanCss = require('gulp-clean-css');

gulp.task('pack-js', function () {
    return gulp.src(['wwwroot/js/lib/wNumb.js', 'wwwroot/js/lib/nouislider.js', 'wwwroot/js/*.js'])
        .pipe(concat('bundle.js'))
        .pipe(minify({
            ext: {
                min: '.js'
            },
            noSource: true
        }))
        .pipe(gulp.dest('wwwroot/dist'));
});

gulp.task('pack-css', function () {
    return gulp.src(['wwwroot/css/lib/*.css', 'wwwroot/css/*.css'])
        .pipe(concat('styles.css'))
        .pipe(cleanCss())
        .pipe(gulp.dest('wwwroot/dist'));
});

gulp.task('default', gulp.series(['pack-js', 'pack-css']));