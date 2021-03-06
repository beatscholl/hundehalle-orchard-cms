/*
** NOTE: This file is generated by Gulp and should not be edited directly!
** Any changes made directly to this file will be overwritten next time its asset group is processed by Gulp.
*/

/// <reference path="ext/fullcalendar/ifullcalendar.ts" />
/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="event.ts" />
var dsc;
(function (dsc) {
    var CalendarWidget = (function () {
        function CalendarWidget(Id, Events) {
            $('#' + Id).fullCalendar({
                lang: navigator.userLanguage,
                theme: false,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                editable: false,
                timezone: 'local',
                events: Events,
                weekNumbers: false
            });
        }
        return CalendarWidget;
    })();
    dsc.CalendarWidget = CalendarWidget;
})(dsc || (dsc = {}));

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIkNhbGVuZGFyV2lkZ2V0LmpzIiwiQ2FsZW5kYXJXaWRnZXQudHMiXSwibmFtZXMiOlsiZHNjIiwiZHNjLkNhbGVuZGFyV2lkZ2V0IiwiZHNjLkNhbGVuZGFyV2lkZ2V0LmNvbnN0cnVjdG9yIl0sIm1hcHBpbmdzIjoiQUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsQUNMQSwwREFBMEQ7QUFDMUQsbURBQW1EO0FBQ25ELGlDQUFpQztBQUVqQyxJQUFPLEdBQUcsQ0FrQlQ7QUFsQkQsV0FBTyxHQUFHLEVBQUMsQ0FBQztJQUNSQTtRQUNJQyx3QkFBWUEsRUFBVUEsRUFBRUEsTUFBbUJBO1lBQ3ZDQyxDQUFDQSxDQUFDQSxHQUFHQSxHQUFHQSxFQUFFQSxDQUFDQSxDQUFDQSxZQUFZQSxDQUFDQTtnQkFDckJBLElBQUlBLEVBQUVBLFNBQVNBLENBQUNBLFlBQVlBO2dCQUM1QkEsS0FBS0EsRUFBRUEsS0FBS0E7Z0JBQ1pBLE1BQU1BLEVBQUVBO29CQUNKQSxJQUFJQSxFQUFFQSxpQkFBaUJBO29CQUN2QkEsTUFBTUEsRUFBRUEsT0FBT0E7b0JBQ2ZBLEtBQUtBLEVBQUVBLDRCQUE0QkE7aUJBQ3RDQTtnQkFDREEsUUFBUUEsRUFBRUEsS0FBS0E7Z0JBQ2ZBLFFBQVFBLEVBQUVBLE9BQU9BO2dCQUNqQkEsTUFBTUEsRUFBRUEsTUFBTUE7Z0JBQ2RBLFdBQVdBLEVBQUVBLEtBQUtBO2FBQ3JCQSxDQUFDQSxDQUFDQTtRQUNQQSxDQUFDQTtRQUNMRCxxQkFBQ0E7SUFBREEsQ0FoQkFELEFBZ0JDQyxJQUFBRDtJQWhCWUEsa0JBQWNBLGlCQWdCMUJBLENBQUFBO0FBQ0xBLENBQUNBLEVBbEJNLEdBQUcsS0FBSCxHQUFHLFFBa0JUIiwiZmlsZSI6IkNhbGVuZGFyV2lkZ2V0LmpzIiwic291cmNlc0NvbnRlbnQiOltudWxsLCIvLy8gPHJlZmVyZW5jZSBwYXRoPVwiZXh0L2Z1bGxjYWxlbmRhci9pZnVsbGNhbGVuZGFyLnRzXCIgLz5cclxuLy8vIDxyZWZlcmVuY2UgcGF0aD1cInR5cGluZ3MvanF1ZXJ5L2pxdWVyeS5kLnRzXCIgLz5cclxuLy8vIDxyZWZlcmVuY2UgcGF0aD1cImV2ZW50LnRzXCIgLz5cclxuXHJcbm1vZHVsZSBkc2Mge1xyXG4gICAgZXhwb3J0IGNsYXNzIENhbGVuZGFyV2lkZ2V0IHtcclxuICAgICAgICBjb25zdHJ1Y3RvcihJZDogc3RyaW5nLCBFdmVudHM6IGRzYy5FdmVudFtdKSB7XHJcbiAgICAgICAgICAgICQoJyMnICsgSWQpLmZ1bGxDYWxlbmRhcih7XHJcbiAgICAgICAgICAgICAgICBsYW5nOiBuYXZpZ2F0b3IudXNlckxhbmd1YWdlLFxyXG4gICAgICAgICAgICAgICAgdGhlbWU6IGZhbHNlLFxyXG4gICAgICAgICAgICAgICAgaGVhZGVyOiB7XHJcbiAgICAgICAgICAgICAgICAgICAgbGVmdDogJ3ByZXYsbmV4dCB0b2RheScsXHJcbiAgICAgICAgICAgICAgICAgICAgY2VudGVyOiAndGl0bGUnLFxyXG4gICAgICAgICAgICAgICAgICAgIHJpZ2h0OiAnbW9udGgsYWdlbmRhV2VlayxhZ2VuZGFEYXknXHJcbiAgICAgICAgICAgICAgICB9LFxyXG4gICAgICAgICAgICAgICAgZWRpdGFibGU6IGZhbHNlLFxyXG4gICAgICAgICAgICAgICAgdGltZXpvbmU6ICdsb2NhbCcsXHJcbiAgICAgICAgICAgICAgICBldmVudHM6IEV2ZW50cyxcclxuICAgICAgICAgICAgICAgIHdlZWtOdW1iZXJzOiBmYWxzZVxyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcbn0iXSwic291cmNlUm9vdCI6Ii9zb3VyY2UvIn0=
