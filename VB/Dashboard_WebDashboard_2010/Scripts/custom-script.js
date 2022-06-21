function switchMode(sender) {
    var control = webDashboard.GetDashboardControl();

    if (control.isDesignMode()) {
        control.switchToViewer();
        button.SetText('Switch to Designer');
    }
    else {
        control.switchToDesigner();
        button.SetText('Switch to Viewer');
    }
}